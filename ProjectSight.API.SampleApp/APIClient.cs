using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Trimble.ProjectSight;
using Trimble.ProjectSight.V1;

namespace ProjectSight.API.SampleApp
{
    public class APIClient : ClientProxyBase
    {
        private const string TID_ENDPOINT_PROD = "https://id.trimble.com";
        private const string TID_ENDPOINT_STAGING = "https://stage.id.trimblecloud.com";

        public const string PROJECTSIGHT_ENDPOINT_PROD = "https://cloud.api.trimble.com/projectsight/us1/1.0";
        public const string PROJECTSIGHT_EU_ENDPOINT_PROD = "https://cloud.api.trimble.com/projectsight/eu1/1.0";
        public const string PROJECTSIGHT_AZURE_ENDPOINT_TEST = "https://cloud.qa.api.trimblecloud.com/projectsight/ops1/1.0";

        public const string TID_ENDPOINT = TID_ENDPOINT_PROD;
        public const string PROJECTSIGHT_ENDPOINT = PROJECTSIGHT_ENDPOINT_PROD;

        // *** this will be called by TID`s redirect ***
        // care should be taken that the given URL will not cause unwanted behavior on the test system
        private const string REDIRECT_URI = "http://127.0.0.1";


        private string m_AccessToken;

        private static HttpClient _client = new HttpClient();

        /// <summary>
        /// Create a new instance of the APIClient.
        /// </summary>
        /// <param name="baseUrl">This is an optional param because the endpoint in the EU is different than that in NA</param>
        /// <remarks>The ClientTimeout passed to the base implementation defaults to 10 minutes to support debugging</remarks>
        public APIClient(string baseUrl = PROJECTSIGHT_ENDPOINT) : base(baseUrl, new TimeSpan(0, 0, 10, 0))
        {
        }

        /// <summary>
        /// Attach IdToken to request Header
        /// </summary>
        /// <param name="request"></param>
        protected override void PrepareRequest(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", $"Bearer {m_AccessToken}");
        }

        /// <summary>
        /// Generate Trimble Identity token for an API application to access Web API
        /// This should be called as it is needed
        /// </summary>
        /// <param name="clientKey">The API Application Client ID</param>
        /// <param name="clientSecret">The API Application Client Secret</param>
        /// <param name="apiApplicationName">The API Application Name</param>
        /// <returns></returns>
        public async Task<string> GenerateApplicationAccessToken(string clientKey, string clientSecret, string apiApplicationName)
        {
            if (string.IsNullOrWhiteSpace(clientKey) || string.IsNullOrWhiteSpace(clientSecret) || string.IsNullOrWhiteSpace(apiApplicationName))
            {
                MessageBox.Show($"{nameof(clientKey)}, {nameof(clientSecret)}, and {nameof(apiApplicationName)} must all be specified.", "Parameter Error", MessageBoxButtons.OK);
                return null;
            }

            m_AccessToken = await GetApplicationAccessTokenFromTID(clientKey, clientSecret, apiApplicationName);

            return m_AccessToken;
        }

        /// <summary>
        /// Generate Trimble Identity token for a user, showing them a TID login prompt
        /// This should be called as it is needed
        /// </summary>
        /// <param name="clientKey">The API Application Client ID</param>
        /// <param name="clientSecret">The API Application Client Secret</param>
        /// <param name="apiApplicationName">The API Application Name</param>
        /// <param name="clearExistingTokenIfSet">Set to true if any existing token needs to be cleared</param>
        /// <returns></returns>
        public async Task<string> GenerateUserAccessToken(string clientKey, string clientSecret, string applicationName)
        {
            if (string.IsNullOrWhiteSpace(clientKey) || string.IsNullOrWhiteSpace(clientSecret))
            {
                MessageBox.Show($"{nameof(clientKey)} and {nameof(clientSecret)} must be specified.", "Parameter Error", MessageBoxButtons.OK);
                return null;
            }

            m_AccessToken = await GetUserAccessTokenFromTID(clientKey, clientSecret, applicationName);

            return m_AccessToken;
        }

        /// <summary>
        /// Obtains the access token for the API application from Trimble Identity
        /// </summary>
        /// <param name="clientKey">The API Application Client ID</param>
        /// <param name="clientSecret">The API Application Client Secret</param>
        /// <param name="apiApplicationName">The API Application Name</param>
        /// <returns></returns>
        private async Task<string> GetApplicationAccessTokenFromTID(string clientKey, string clientSecret, string apiApplicationName)
        {
            // Provide the body information required by TID to process the request
            var body = new Dictionary<string, string>();
            body.Add("grant_type", "client_credentials");
            body.Add("scope", apiApplicationName);

            var token = await ProcessTIDTokenRequest(clientKey, clientSecret, body);
            return token?.AccessToken;
        }

        /// <summary>
        /// Show the user the TID login and then exchange the authCode it returns for an access token
        /// </summary>
        /// <param name="clientKey"></param>
        /// <param name="clientSecret"></param>
        /// <param name="applicationName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> GetUserAccessTokenFromTID(string clientKey, string clientSecret, string applicationName)
        {
            // Exceptions are handled by the caller

            const string AUTHORIZATION_ENDPOINT = TID_ENDPOINT + "/oauth/authorize";

            using (var webDriver = new ChromeDriver(GetDriverService(), GetDriverOptions()))
            {
                /* Open Trimble Identity sign in page */
                try
                {
                    // Clear cookies before sending to TID.
                    webDriver.Manage().Cookies.DeleteAllCookies();

                    webDriver.Url = $"{AUTHORIZATION_ENDPOINT}?client_id={clientKey}&response_type=code&scope=openid {applicationName}&redirect_uri={REDIRECT_URI}";
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to launch Trimble Identity sign in page", ex);
                }

                var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(5.0));
                /* Redirect URL callback handler */
                wait.Until(driver => driver.Url.StartsWith(REDIRECT_URI));
                var redirectUri = new Uri(webDriver.Url, UriKind.Absolute);

                TIDResponse token = null;

                // Remove the leading ?
                var parameters = redirectUri.Query.Remove(0, 1).Split('&').ToDictionary(c => c.Split('=')[0], c => Uri.UnescapeDataString(c.Split('=')[1]), StringComparer.InvariantCultureIgnoreCase);
                if (parameters.TryGetValue("code", out var authCode))
                {
                    // This will throw an exception on error
                    token = await AcquireTokenByAuthorizationCodeAsync(clientKey, clientSecret, authCode);
                }

                if (token == null)
                {
                    throw new Exception("Failed to validate authorization code");
                }

                return token?.AccessToken;
            }
        }

        /// <summary>
        /// Convert a OpenID code into an identity token
        /// </summary>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public async Task<TIDResponse> AcquireTokenByAuthorizationCodeAsync(string clientKey, string clientSecret, string authCode)
        {
            // Exceptions are handled by the caller

            var body = new Dictionary<string, string>();
            body.Add("grant_type", "authorization_code");
            body.Add("code", authCode);
            body.Add("client_id", clientKey);
            body.Add("redirect_uri", REDIRECT_URI);

            return await ProcessTIDTokenRequest(clientKey, clientSecret, body);
        }

        /// <summary>
        /// Obtains the access token for the API application from Trimble Identity
        /// </summary>
        /// <param name="clientKey">The API Application Client ID</param>
        /// <param name="clientSecret">The API Application Client Secret</param>
        /// <param name="apiApplicationName">The API Application Name</param>
        /// <returns></returns>
        private async Task<TIDResponse> ProcessTIDTokenRequest(string clientKey, string clientSecret, Dictionary<string, string> body)
        {
            const string TOKEN_ENDPOINT = TID_ENDPOINT + "/oauth/token";

            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Provide the authorization required by TID
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", $"{Convert.ToBase64String(Encoding.UTF8.GetBytes(clientKey + ":" + clientSecret))}");

                // Post the request to TID
                var request = new HttpRequestMessage(HttpMethod.Post, TOKEN_ENDPOINT) { Content = new FormUrlEncodedContent(body) };
                var response = await _client.SendAsync(request);
                // Verify the response
                response.EnsureSuccessStatusCode();

                // Process the response from TID
                var responseData = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<TIDResponse>(responseData);
                if (!string.IsNullOrEmpty(result?.Error))
                {
                    System.Diagnostics.Debug.WriteLine($"{result.Error}: {result.ErrorDescription}");
                    return null;
                }

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Verifies that the response from ProjectSight API request was successful
        /// </summary>
        /// <returns></returns>
        public bool VerifyResponseIsOk()
        {
            if (LastResponse == null)
            {
                MessageBox.Show("No response", "No Response", MessageBoxButtons.OK);
                return false;
            }

            if (LastResponse.StatusCode != HttpStatusCode.OK)
            {
                if (string.IsNullOrEmpty(LastResponse.Message))
                {
                    MessageBox.Show($"Server returned code {LastResponse.StatusCode}", "Server Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(LastResponse.Message, "Application Error", MessageBoxButtons.OK);
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Process Response to get result for non ok status codes.
        /// </summary>
        /// <param name="response"></param>
        public bool ProcessWebResponse(HttpWebResponse response, bool okToReadContent = true)
        {
            // Exceptions are handled by the caller

            LastResponse.StatusCode = response.StatusCode;
            LastResponse.Message = "";
            LastResponse.Code = 0;
            LastResponse.Content = "";

            // Copy the response to Property ClientResponse to use it for non-ok results
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.PartialContent)
            {
                if (okToReadContent)
                {
                    LastResponse.Content = ReadWebResponseContent(response).Result;
                }

                return true;
            }

            var responseData = ReadWebResponseContent(response).Result;

            LastResponse.Content = responseData;

            // NotFound will result in an Http page, so do not attempt to parse it.
            if (!string.IsNullOrEmpty(responseData) && response.StatusCode != HttpStatusCode.NotFound)
            {
                try
                {
                    var error = JsonConvert.DeserializeObject<ErrorResult>(responseData);
                    if (error != null)
                    {
                        LastResponse.Message = error.Message;
                        if (OkToThrowExceptionOnErrorResult)
                        {
                            throw new ProjectSightException(LastResponse.Message, LastResponse.StatusCode, responseData, null);
                        }
                    }
                }
                catch (JsonReaderException ex)
                {
                    LastResponse.Message = ex.Message;
                    if (OkToThrowExceptionOnErrorResult)
                    {
                        throw new ProjectSightException(LastResponse.Message, LastResponse.StatusCode, responseData, ex);
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// Read response content as string
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static async Task<string> ReadWebResponseContent(HttpWebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                {
                    return string.Empty;
                }

                using (var reader = new StreamReader(responseStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        #region User Login

        private static ChromeDriverService GetDriverService()
        {
            // Exceptions are handled by the caller

            var myExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driverService = ChromeDriverService.CreateDefaultService(myExe);
            driverService.HideCommandPromptWindow = true;
            driverService.SuppressInitialDiagnosticInformation = true;

            return driverService;
        }

        private static ChromeOptions GetDriverOptions()
        {
            // Exceptions are handled by the caller

            var options = new ChromeOptions();
            options.AddArgument("--silent");
            options.AddArgument("--log-level=3");
            return options;
        }


        #endregion // User Login
    }
}
