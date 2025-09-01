using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trimble.ProjectSight;
using Trimble.ProjectSight.V1;

namespace ProjectSight.API.SampleApp
{
    public partial class Form1 : Form
    {
        private APIClient _apiClient;
        private bool _refreshToken;


        public Form1()
        {
            InitializeComponent();
        }

        private async Task<APIClient> GetAPIClient()
        {
            var generateAccessToken = _refreshToken || _apiClient == null;
            // Reset this now
            _refreshToken = false;

            if (_apiClient == null)
            {
                _apiClient = new APIClient();
            }

            if (generateAccessToken)
            {
                if (chkPromptUser.Checked)
                {
                    await _apiClient.GenerateUserAccessToken(txtClientID.Text, txtClientSecret.Text, txtApplicationName.Text);
                }
                else
                {
                    await _apiClient.GenerateApplicationAccessToken(txtClientID.Text, txtClientSecret.Text, txtApplicationName.Text);
                }
            }

            return _apiClient;
        }

        #region Portfolios

        /// <summary>
        /// Retrieve the list of portfolios the user associated with the API application has access to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGetPortfolios_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetPortfolioListAsync(System.Threading.CancellationToken.None);
            if (_apiClient.VerifyResponseIsOk())
            {
                cboPortfolios.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} portfolios");

                ClearAllPortfolioItems();
            }
        }

        /// <summary>
        /// When the portfolio selection is changed, the projects need to be reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPortfolios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllPortfolioItems();
        }

        /// <summary>
        /// Clear all items that have been loaded from the portfolio
        /// </summary>
        private void ClearAllPortfolioItems()
        {
            ClearProjectsList();
            ClearCompaniesList();
            ClearUsersList();
            ClearUDFs();
            ClearReports();
            ClearLookupLists();
        }

        /// <summary>
        /// Gets the currently selected portfolio id
        /// </summary>
        /// <returns></returns>
        private Guid CurrentPortfolioId
        {
            get
            {
                if (cboPortfolios.SelectedItem == null)
                {
                    return Guid.Empty;
                }

                return ((Portfolio)cboPortfolios.SelectedItem).PortfolioID.Value;
            }
        }

        #endregion // Portfolios

        #region Projects

        /// <summary>
        /// Load the list of projects for the currently selected portfolio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGetProjects_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetProjectListOnlyAsync(CurrentPortfolioId);
            if (_apiClient.VerifyResponseIsOk())
            {
                cboProjects.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} projects");

                ClearProjectRelatedItems();
            }
        }

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearProjectRelatedItems();
        }

        private void ClearProjectRelatedItems()
        {
            ClearWorkflowStates();
            ClearRecords();
        }

        private void ClearProjectsList()
        {
            btnGetProjects.Enabled = cboPortfolios.Items.Count > 0;

            cboProjects.SelectedItem = null;
            cboProjects.DataSource = new List<Project>();
        }

        /// <summary>
        /// Gets the currently selected project id
        /// </summary>
        /// <returns></returns>
        private int CurrentProjectId
        {
            get
            {
                if (cboProjects.SelectedItem == null)
                {
                    return 0;
                }

                return ((Project)cboProjects.SelectedItem).ProjectID.Value;
            }
        }

        #endregion // Projects

        #region Companies

        private async void btnLoadCompanies_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetCompanyListOnlyAsync(CurrentPortfolioId);
            if (_apiClient.VerifyResponseIsOk())
            {
                cboCompanies.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} companies");
            }
        }

        private void ClearCompaniesList()
        {
            btnLoadCompanies.Enabled = cboPortfolios.Items.Count > 0;

            cboCompanies.SelectedItem = null;
            cboCompanies.DataSource = new List<Company>();
        }

        #endregion // Companies

        #region Users

        private async void btnLoadUsers_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetUserListAsync<User>(CurrentPortfolioId);
            if (_apiClient.VerifyResponseIsOk())
            {
                cboUsers.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} users");
            }
        }

        private void ClearUsersList()
        {
            btnLoadUsers.Enabled = cboPortfolios.Items.Count > 0;

            cboUsers.SelectedItem = null;
            cboUsers.DataSource = new List<User>();
        }

        #endregion // Users

        #region WorkflowStates

        private async void btnLoadProjectRFIWorkflowStates_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetRFIWorkflowStatesAsync(CurrentPortfolioId, CurrentProjectId);
            if (_apiClient.VerifyResponseIsOk())
            {
                cboProjectRFIWorkflowStates.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} workflow states");
            }
        }

        private void ClearWorkflowStates()
        {
            btnLoadProjectRFIWorkflowStates.Enabled = cboProjects.Items.Count > 0;

            cboProjectRFIWorkflowStates.SelectedItem = null;
            cboProjectRFIWorkflowStates.DataSource = new List<WorkflowState>();
        }


        /// <summary>
        /// Finds the first non-Draft workflow state in the current project for RFIs
        /// </summary>
        /// <returns></returns>
        private async Task<int> GetNonDraftRFIWorkflowState()
        {
            var client = await GetAPIClient();
            var workflowStates = await client.GetRFIWorkflowStatesAsync(CurrentPortfolioId, CurrentProjectId, System.Threading.CancellationToken.None);

            foreach (var workflowstate in workflowStates)
            {
                if (!workflowstate.LocksRecords && workflowstate.Type != WorkflowState.Types.Draft)
                {
                    return workflowstate.RecordId;
                }
            }

            return 0;
        }

        #endregion // WorkflowStates

        #region UDFs

        private async void btnLoadRFIUDFs_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetRFIUDFsAsync(CurrentPortfolioId);
            if (_apiClient.VerifyResponseIsOk())
            {
                cboRFIUDFs.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} UDFs");
            }
        }

        private void ClearUDFs()
        {
            btnLoadRFIUDFs.Enabled = cboPortfolios.Items.Count > 0;

            cboRFIUDFs.SelectedItem = null;
            cboRFIUDFs.DataSource = new List<UDF>();
        }

        #endregion // UDFs

        #region LookupLists

        private async void btnLoadLookupLists_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetAvailableLookupListTypesAsync(CurrentPortfolioId, 0);
            if (_apiClient.VerifyResponseIsOk())
            {
                cboLookupLists.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} Lookup Lists");

                ClearLookupListEntries();
            }
        }

        private void cboLookupLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearLookupListEntries();
        }

        private void ClearLookupLists()
        {
            btnLoadLookupLists.Enabled = cboPortfolios.Items.Count > 0;

            cboLookupLists.SelectedItem = null;
            cboLookupLists.DataSource = new List<LookupListType>();

            ClearLookupListEntries();
        }

        /// <summary>
        /// Gets the currently selected project id
        /// </summary>
        /// <returns></returns>
        private int GetCurrentLookupListType()
        {
            if (cboLookupLists.SelectedItem == null)
            {
                return 0;
            }

            return ((LookupListType)cboLookupLists.SelectedItem).Section;
        }

        private async void btnLoadPortfolioLookupListEntries_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetLookupListBySectionIDAsync(CurrentPortfolioId, 0, GetCurrentLookupListType());
            if (_apiClient.VerifyResponseIsOk())
            {
                cboPortfolioLookupListEntries.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} Lookup List Entries");
            }
        }

        private void ClearLookupListEntries()
        {
            btnLoadPortfolioLookupListEntries.Enabled = cboLookupLists.Items.Count > 0;

            cboPortfolioLookupListEntries.SelectedItem = null;
            cboPortfolioLookupListEntries.DataSource = new List<LookupListItem>();
        }

        #endregion // LookupList

        #region Reports

        private async void btnLoadRFIReports_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var records = await client.GetRFIReportsAsync(CurrentPortfolioId);
            if (_apiClient.VerifyResponseIsOk())
            {
                cboRFIReports.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} Reports");
            }
        }

        private void ClearReports()
        {
            btnLoadRFIReports.Enabled = cboPortfolios.Items.Count > 0;

            cboRFIReports.SelectedItem = null;
            cboRFIReports.DataSource = new List<Report>();
        }

        #endregion // Reports

        #region Records

        /// <summary>
        /// Loads the first 10 RFIs in the current project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLoadRFIs_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            // Only fetch 10 records
            var records = await client.GetRFIListOnlyAsync(CurrentPortfolioId, CurrentProjectId, 0, 10);
            if (_apiClient.VerifyResponseIsOk())
            {
                ClearRecords();

                cboRFIs.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} RFIs");
            }
        }

        /// <summary>
        /// Loads RFIs that have been modified in the past 10 minutes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLoadRFIsModifiedInLast10Minutes_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();

            var request = new QueryRequest();
            // Limit the project to the current one
            request.AddProject(CurrentProjectId);
            // Add a filter to the request to just fetch records modified in the list 10 minutes
            request.AddFilter("LastModified", QueryRequestFilterCondition.ComparisonTypes.GreaterThanOrEqualTo, DateTimeOffset.Now.AddMinutes(-10));

            // Only fetch 10 records
            var records = await client.GetRFIListOnlyAsync(CurrentPortfolioId, request);
            if (_apiClient.VerifyResponseIsOk())
            {
                ClearRecords();

                cboRFIs.DataSource = records;
                MessageBox.Show($"Retrieved {records.Count} RFIs");
            }
        }

        private void ClearRecords()
        {
            btnLoadRFIs.Enabled = cboProjects.Items.Count > 0;
            btnLoadRFIsModifiedInLast10Minutes.Enabled = cboProjects.Items.Count > 0;

            btnCreateRFIOnBehalfOfContact.Enabled = cboProjects.Items.Count > 0;
            btnCreateRFIOnBehalfOfContactID.Enabled = cboProjects.Items.Count > 0;
            btnCreateRFIOnBehalfOfUser.Enabled = cboProjects.Items.Count > 0;
            btnCreateRFIWithExternalFile.Enabled = cboProjects.Items.Count > 0;
            btnCreateRFIWithUDFs.Enabled = cboProjects.Items.Count > 0;

            cboRFIs.SelectedItem = null;
            cboRFIs.DataSource = new List<RFI>();
        }


        #region UDFs

        /// <summary>
        /// Creates an RFI with a UDF and then reads the record back.
        /// This method assumes that a UDF called TextField, of type Text, has been added to the RFI in the selected portfolio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCreateRFIWithUDFs_Click(object sender, EventArgs e)
        {
            var client = await GetAPIClient();
            var rfi = await GenerateRFI<RFIWithUDFs>();
            rfi.udf_TextField = "ABC";
            rfi = _apiClient.CreateOrUpdateRFI(CurrentPortfolioId, CurrentProjectId, rfi);
            _apiClient.VerifyResponseIsOk();

            // Now read the RFI back (to illustrate the use of generics)
            rfi = await client.GetRFIByIDAsync<RFIWithUDFs>(CurrentPortfolioId, CurrentProjectId, rfi.RFI_ID.Value, System.Threading.CancellationToken.None);
            _apiClient.VerifyResponseIsOk();

            MessageBox.Show($"Created RFI {rfi.Number} with UDF TextField {rfi.udf_TextField}");
        }

        #endregion // UDFs

        #region Attaching Files

        /// <summary>
        /// Creates an RFI with 2 files attached directly to it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCreateRFIWithExternalFile_Click(object sender, EventArgs e)
        {
            // Get files to upload
            var localFile1 = GetFileToUpload("Select First File To Upload");
            if (string.IsNullOrEmpty(localFile1))
            {
                return;
            }

            var localFile2 = GetFileToUpload("Select Second File To Upload");
            if (string.IsNullOrEmpty(localFile2))
            {
                return;
            }

            // Get S3 pre-signed URLs for the two files that were selected
            var client = await GetAPIClient();
            var result = await client.RequestPresignedFileLinksAsync(CurrentPortfolioId, CurrentProjectId, 2, System.Threading.CancellationToken.None);
            if (!_apiClient.VerifyResponseIsOk())
            {
                return;
            }

            var externalFileLocation1 = result[0];

            // Upload file
            if (!await UploadFile(localFile1, externalFileLocation1))
            {
                return;
            }

            var externalFileLocation2 = result[1];

            // Upload file
            if (!await UploadFile(localFile2, externalFileLocation2))
            {
                return;
            }

            // Create an RFI with link to the files that were uploaded to s3
            var rfi = await GenerateRFI();
            rfi.FileLinks.Add(new FileLink { FileLocation = externalFileLocation1, RequestedFileName = Path.GetFileName(localFile1) });
            rfi.FileLinks.Add(new FileLink { FileLocation = externalFileLocation2, RequestedFileName = Path.GetFileName(localFile2) });
            rfi = await client.CreateOrUpdateRFIAsync(CurrentPortfolioId, CurrentProjectId, rfi, System.Threading.CancellationToken.None);
            if (!_apiClient.VerifyResponseIsOk())
            {
                return;
            }

            MessageBox.Show($"Created RFI {rfi.Number}", "Success", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Ask the end user to pick a file from the local file system
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private string GetFileToUpload(string title = "Select File To Upload")
        {
            var dialog = new OpenFileDialog();
            dialog.Title = title;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return string.Empty;
            }

            return dialog.FileName;
        }

        /// <summary>
        /// This method is used to upload a file to the specified external file location from the specified file name
        /// </summary>
        /// <param name="toExternalFileLocation"></param>
        /// <returns></returns>
        private async Task<bool> UploadFile(string fromFileName, string toExternalFileLocation)
        {
            // Exceptions are handled by the caller

            var httpRequest = (HttpWebRequest)WebRequest.Create(toExternalFileLocation);
            httpRequest.Method = "PUT";
            using (var dataStream = httpRequest.GetRequestStream())
            {
                using (var fileStream = new FileStream(fromFileName, FileMode.Open, FileAccess.Read))
                {
                    await fileStream.CopyToAsync(dataStream);
                }
            }

            _apiClient.ProcessWebResponse((HttpWebResponse)httpRequest.GetResponse(), false);

            return _apiClient.VerifyResponseIsOk();
        }

        #endregion // Attaching Files

        #region Helpers

        /// <summary>
        /// Generates a non-draft RFI with details
        /// </summary>
        /// <returns></returns>
        protected async Task<RFI> GenerateRFI()
        {
            return await GenerateRFI<RFI>();
        }

        /// <summary>
        /// Generate a new non-draft RFI with details
        /// </summary>
        /// <returns></returns>
        protected async Task<T> GenerateRFI<T>() where T : RFI, new()
        {
            return new T
            {
                Subject = "Test For API Integration",
                SharedWith = RFI.SharedWithTypes.EntireProject,
                DateCreated = DateTimeOffset.Now,
                WorkflowState = await GetNonDraftRFIWorkflowState(),
                RecordComments = new List<Comment> { new Comment { Comments = "Test Details", Type = Comment.CommentType.Details } },
                FileLinks = new List<FileLink>()
            };
        }

        #endregion // Helpers

        #endregion // Records

        #region On-Behalf of Operations

        /// <summary>
        /// Creates an RFI on behalf of a user other than the API user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateRFIOnBehalfOfUser_Click(object sender, EventArgs e)
        {
            CreateRFIOnBehalfOf(APISupport.HEADER_ON_BEHALF_OF_USER, txtOnBehalfOf.Text);
        }

        /// <summary>
        /// Creates an RFI on behalf of a contact email address in the portfolio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateRFIOnBehalfOfContact_Click(object sender, EventArgs e)
        {
            CreateRFIOnBehalfOf(APISupport.HEADER_ON_BEHALF_OF_CONTACT, txtOnBehalfOf.Text);
        }

        /// <summary>
        /// Creates an RFI on behalf of a ContactID from the portfolio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateRFIOnBehalfOfContactID_Click(object sender, EventArgs e)
        {
            CreateRFIOnBehalfOf(APISupport.HEADER_ON_BEHALF_OF_CONTACTID, txtOnBehalfOf.Text);
        }

        /// <summary>
        /// Worker method for 3 of the on-behalf of scenarios.
        /// Note that the Security Role for the API user must be explicitly granted the Feature
        /// Record Features > Can perform actions on behalf of other users via the API
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        private async void CreateRFIOnBehalfOf(string header, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show($"Please enter an On-Behalf-Of Identifier");
                return;
            }

            try
            {
                // Ask the API to perform the actions on behalf of the specified user
                _apiClient.PerformSubsequentActionsOnBehalfOf(header, value);

                // Create RFI
                var rfi = await GenerateRFI();
                rfi.Subject = "Creating " + header + " " + value;
                var client = await GetAPIClient();
                rfi = await client.CreateOrUpdateRFIAsync(CurrentPortfolioId, CurrentProjectId, rfi, System.Threading.CancellationToken.None);
                if (!_apiClient.VerifyResponseIsOk())
                {
                    return;
                }

                MessageBox.Show($"Created RFI {rfi.Number}", "Success", MessageBoxButtons.OK);
            }
            finally
            {
                // Tell the API we are done performing on-behalf-of actions
                _apiClient.ResetOnBehalfOf();
            }
        }

        #endregion // On-Behalf of Operations

        #region Credentials

        /// <summary>
        /// When the client id, secret or application name is changed, indicate the token needs to be refreshed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CredentialTextBoxChanged(object sender, EventArgs e)
        {
            _refreshToken = true;
        }

        private void chkPromptUser_CheckedChanged(object sender, EventArgs e)
        {
            _refreshToken = true;
        }

        #endregion // Credentials
    }
}