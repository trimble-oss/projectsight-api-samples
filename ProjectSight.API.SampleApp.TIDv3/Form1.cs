using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trimble.ProjectSight;
using Trimble.ProjectSight.V1;

namespace ProjectSight.API.SampleApp.TIDv3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Do NOT use ProjectSight_AdminUser1: it will trigger API test behavior
        /// </summary>
        private Guid PORTFOLIOID = Guid.Parse("4080da15-f257-4e22-a9ef-6b8cfa264d67");
        private const int PROJECTID = 1;
        private const string URL = "https://api-usw2.trimblepaas.com/projectsight-v1.0/";

        private APIClient m_APIClient;

        public Form1()
        {
            InitializeComponent();

            m_APIClient = new APIClient(URL);
        }

        private async void cmdProcessRFIWithUDFs_Click(object sender, EventArgs e)
        {
            var rfi = await m_APIClient.GetRFIByIDAsync<RFIWithUDFs>(PORTFOLIOID, PROJECTID, 1, System.Threading.CancellationToken.None);
            if (!m_APIClient.VerifyResponseIsOk())
            {
                return;
            }

        }

        private async void cmdCreateRFIWithExternalFile_Click(object sender, EventArgs e)
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

            // Get S3 placeholder
            var result = await m_APIClient.RequestPresignedFileLinksAsync(PORTFOLIOID, PROJECTID, 2, System.Threading.CancellationToken.None);
            if (!m_APIClient.VerifyResponseIsOk())
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

            // Create RFI with link to file
            var rfi = await GenerateRFI();
            rfi.FileLinks.Add(new FileLink { FileLocation = externalFileLocation1, RequestedFileName = Path.GetFileName(localFile1) });
            rfi.FileLinks.Add(new FileLink { FileLocation = externalFileLocation2, RequestedFileName = Path.GetFileName(localFile2) });
            rfi = await m_APIClient.CreateOrUpdateRFIAsync(PORTFOLIOID, PROJECTID, rfi, System.Threading.CancellationToken.None);
            if (!m_APIClient.VerifyResponseIsOk())
            {
                return;
            }

            MessageBox.Show("Created RFI " + rfi.RFI_ID, "Success", MessageBoxButtons.OK);
        }

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
        /// Generate a new non-draft RFI with details
        /// </summary>
        /// <returns></returns>
        protected async Task<RFI> GenerateRFI()
        {
            return new RFI
            {
                Subject = "Test For Comment Section",
                SharedWith = RFI.SharedWithTypes.EntireProject,
                DateCreated = DateTime.UtcNow,
                WorkflowState = await GetNonDraftWorkflowState(),
                RecordComments = new List<Comment> { new Comment { Comments = "Test Details", Type = Comment.CommentType.Details } },
                FileLinks = new List<FileLink>()
            };
        }

        private int m_nonDraftWorkflowState;

        private async Task<int> GetNonDraftWorkflowState()
        {
            if (m_nonDraftWorkflowState != 0)
            {
                return m_nonDraftWorkflowState;
            }

            var workflowStates = await m_APIClient.GetRFIWorkflowStatesAsync(PORTFOLIOID, PROJECTID, System.Threading.CancellationToken.None);

            foreach (var workflowstate in workflowStates)
            {
                if (!workflowstate.LocksRecords && workflowstate.Type != WorkflowState.Types.Draft)
                {
                    m_nonDraftWorkflowState = workflowstate.RecordId;
                    break;
                }
            }

            return m_nonDraftWorkflowState;
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

            m_APIClient.ProcessWebResponse((HttpWebResponse)httpRequest.GetResponse(), false);

            return m_APIClient.VerifyResponseIsOk();
        }

        private void cmdCreateRFIOnBehalfOfUser_Click(object sender, EventArgs e)
        {
            CreateRFIOnBehalfOf(APISupport.HEADER_ON_BEHALF_OF_USER, "fred.bloggs@competent.com");
        }

        private void cmdCreateRFIOnBehalfOfContact_Click(object sender, EventArgs e)
        {
            CreateRFIOnBehalfOf(APISupport.HEADER_ON_BEHALF_OF_CONTACT, "anewtestcontact@competent.com");
        }

        private void cmdCreateRFIOnBehalfOfContactID_Click(object sender, EventArgs e)
        {
            CreateRFIOnBehalfOf(APISupport.HEADER_ON_BEHALF_OF_CONTACTID, "3069");
        }

        private async void cmdCreateRFIOnBehalfOfPlainText_Click(object sender, EventArgs e)
        {
            try
            {
                const string HEADER_NAME = APISupport.HEADER_ON_BEHALF_OF_PLAIN_TEXT;
                const string HEADER_VALUE = "Unknown User <unknown@competent.com>";

                // Create RFI
                var rfi = await GenerateRFI();
                rfi.AuthorContactID = 3076;
                rfi.Subject = "Creating " + HEADER_NAME + " " + HEADER_VALUE;
                rfi = await m_APIClient.CreateOrUpdateRFIAsync(PORTFOLIOID, PROJECTID, rfi, System.Threading.CancellationToken.None);
                if (!m_APIClient.VerifyResponseIsOk())
                {
                    return;
                }

                MessageBox.Show("Created RFI " + rfi.RFI_ID, "Success", MessageBoxButtons.OK);
            }
            finally
            {
                m_APIClient.ResetOnBehalfOf();
            }
        }

        private async void CreateRFIOnBehalfOf(string header, string value)
        {
            // Exceptions are handled by the caller
            try
            {
                m_APIClient.PerformSubsequentActionsOnBehalfOf(header, value);

                // Create RFI
                var rfi = await GenerateRFI();
                rfi.Subject = "Creating " + header + " " + value;
                rfi = await m_APIClient.CreateOrUpdateRFIAsync(PORTFOLIOID, PROJECTID, rfi, System.Threading.CancellationToken.None);
                if (!m_APIClient.VerifyResponseIsOk())
                {
                    return;
                }

                MessageBox.Show("Created RFI " + rfi.RFI_ID, "Success", MessageBoxButtons.OK);
            }
            finally
            {
                m_APIClient.ResetOnBehalfOf();
            }
        }

        private async void cmdCreateMeetingForToday_Click(object sender, EventArgs e)
        {
            var meeting = GenerateMeeting();

            var files = GetFilesToUpload(2);
            if (files == null)
            {
                return;
            }

            int NumberOfFiles = files.Count;
            int index = 0;

            if (NumberOfFiles > 0 && !string.IsNullOrWhiteSpace(files[0]))
            {
                meeting.FileLinks = new List<FileLink>();

                var result = await m_APIClient.RequestPresignedFileLinksAsync(PORTFOLIOID, PROJECTID, NumberOfFiles, System.Threading.CancellationToken.None);
                if (!m_APIClient.VerifyResponseIsOk())
                {
                    return;
                }

                foreach (var file in files)
                {
                    var s3BucketLocation = result[index];

                    if (!await UploadFile(file, s3BucketLocation))
                    {
                        return;
                    }

                    var fl = new FileLink { FileLocation = s3BucketLocation, RequestedFileName = file };

                    meeting.FileLinks.Add(fl);
                    index += 1;
                }

                meeting = await m_APIClient.CreateOrUpdateMeetingAsync(PORTFOLIOID, PROJECTID, meeting, System.Threading.CancellationToken.None);
                if (!m_APIClient.VerifyResponseIsOk())
                {
                    return;
                }
            }

            MessageBox.Show("Created meeting " + meeting.MeetingID, "Success", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Create GI
        /// </summary>
        /// <returns></returns>
        protected Trimble.ProjectSight.V1.Meeting GenerateMeeting(int workflowState = 235)
        {
            var record = new Trimble.ProjectSight.V1.Meeting();
            record.WorkflowState = workflowState;
            record.MeetingNameID = 2950;
            record.LocationID = 2947;
            record.Date = DateTime.UtcNow;
            record.StartTime = new TimeSpan(10, 0, 0);
            record.EndTime = new TimeSpan(11, 0, 0);
            record.Purpose = "A purpose";
            record.SharedWith = Trimble.ProjectSight.V1.Meeting.SharedWithTypes.EntireProject;
            return record;
        }

        private List<string> GetFilesToUpload(int count)
        {
            var files = new List<string>();

            for (var nI = 0; nI < count; nI++)
            {
                var localFile = GetFileToUpload("Select File To Upload");
                if (string.IsNullOrEmpty(localFile))
                {
                    return null;
                }

                files.Add(localFile);
            }

            return files;
        }

        private async void btnGetPortfolios_Click(object sender, EventArgs e)
        {
            var portfolios = await m_APIClient.GetPortfolioListAsync(System.Threading.CancellationToken.None);
            if (m_APIClient.VerifyResponseIsOk())
            {
                MessageBox.Show($"Retrieved {portfolios.Count} portfolios");
            }
        }
    }
}
