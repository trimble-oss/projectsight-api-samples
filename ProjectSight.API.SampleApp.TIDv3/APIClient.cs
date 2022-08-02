using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Trimble.Identity;
using Trimble.ProjectSight;
using Trimble.ProjectSight.V1;

namespace ProjectSight.API.SampleApp.TIDv3
{
    public class APIClient : ClientProxyBase
    {
        private const string CLIENT_KEY = "";
        private const string CLIENT_SECRET = "";

        private const string USER_NAME = "";
        private const string USER_PASSWORD = "";

        // ReSharper disable once CommentTypo
        // this is the Package & Usage Plan Key from api.trimblepaas.com, Discover API, select ProjectSight, then press Get Key
        private const string API_KEY = "";

        private string m_AccessToken;

        // Default the ClientTimeout to 10 minutes to support debugging
        public APIClient(string baseUrl) : base(baseUrl, new TimeSpan(0, 0, 10, 0))
        {
        }

        /// <summary>
        /// Attach IdToken to request Header
        /// (This header is added to simulate the request is coming from TPaaS;
        ///     On the same line, as alternate, for debug configuration (only), API request can accept the access token directly in header.
        ///     which will be used to retrieve the required email to login.)
        ///  "x-jwt-assertion" should not be exposed outside of Trimble.
        /// </summary>
        /// <param name="request"></param>
        protected override void PrepareRequest(HttpRequestMessage request)
        {
            var token = GetAccessToken();
            request.Headers.Add("Authorization", "Bearer " + token);
            request.Headers.Add("x-api-key", API_KEY);
        }

        /// <summary>
        /// Generate Trimble Identity token for given credentials to access Web API
        /// </summary>
        /// <returns></returns>
        private string GetAccessToken()
        {
            if (string.IsNullOrEmpty(m_AccessToken))
            {
                m_AccessToken = AsyncHelper.RunSync(GetAccessTokenFromTID);
            }

            return m_AccessToken;
        }

        private async Task<string> GetAccessTokenFromTID()
        {
            var clientCredentials = new ClientCredential(CLIENT_KEY, CLIENT_SECRET, "ProjectSight");

            var context = new AuthenticationContext(clientCredentials)
            {
                AuthorityUri = new Uri("https://identity.trimble.com/i/oauth2/")
            };

            try
            {
                var token = await context.AcquireTokenAsync(new NetworkCredential(USER_NAME, USER_PASSWORD));

                return token.AccessToken;
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public bool VerifyResponseIsOk()
        {
            if (this.LastResponse == null)
            {
                MessageBox.Show("No response", "No Response", MessageBoxButtons.OK);
                return false;
            }

            if (this.LastResponse.StatusCode != HttpStatusCode.OK)
            {
                if (string.IsNullOrEmpty(this.LastResponse.Message))
                {
                    MessageBox.Show("Server returned code " + this.LastResponse.StatusCode, "Server Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(this.LastResponse.Message, "Application Error", MessageBoxButtons.OK);
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Process Response to get result for non ok status codes.
        /// Changing the status code manually as NoContent to avoid throwing exception for non ok results
        /// </summary>
        /// <param name="response"></param>
        public bool ProcessWebResponse(HttpWebResponse response, bool okToReadContent = true)
        {
            // Exceptions are handled by the caller

            this.LastResponse.StatusCode = response.StatusCode;
            this.LastResponse.Message = "";
            this.LastResponse.Code = 0;
            this.LastResponse.Content = "";

            // Copy the response to Property ClientResponse to use it for non-ok results
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.PartialContent)
            {
                if (okToReadContent)
                {
                    this.LastResponse.Content = ReadWebResponseContent(response).Result;
                }

                return true;
            }
            // Not found will return web page error, so do not attempt to process it
            else
            {
                var responseData = ReadWebResponseContent(response).Result;

                this.LastResponse.Content = responseData;

                // NotFound will result in an Http page, so do not attempt to parse it.
                if (!string.IsNullOrEmpty(responseData) && response.StatusCode != HttpStatusCode.NotFound)
                {
                    try
                    {
                        var error = JsonConvert.DeserializeObject<ErrorResult>(responseData);
                        if (error != null)
                        {
                            this.LastResponse.Message = error.Message;
                            if (OkToThrowExceptionOnErrorResult)
                            {
                                throw new ProjectSightException(this.LastResponse.Message, this.LastResponse.StatusCode, responseData, null);
                            }
                        }
                    }
                    catch (JsonReaderException ex)
                    {
                        this.LastResponse.Message = ex.Message;
                        if (OkToThrowExceptionOnErrorResult)
                        {
                            throw new ProjectSightException(this.LastResponse.Message, this.LastResponse.StatusCode, responseData, ex);
                        }
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
        public async Task<string> ReadWebResponseContent(HttpWebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                {
                    return string.Empty;
                }

                using (var reader = new System.IO.StreamReader(responseStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

    }
}
