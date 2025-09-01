namespace ProjectSight.API.SampleApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateRFIWithExternalFile = new System.Windows.Forms.Button();
            this.btnCreateRFIOnBehalfOfUser = new System.Windows.Forms.Button();
            this.btnCreateRFIOnBehalfOfContact = new System.Windows.Forms.Button();
            this.btnCreateRFIOnBehalfOfContactID = new System.Windows.Forms.Button();
            this.btnCreateRFIWithUDFs = new System.Windows.Forms.Button();
            this.btnGetPortfolios = new System.Windows.Forms.Button();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPromptUser = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApplicationName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPortfolios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProjects = new System.Windows.Forms.ComboBox();
            this.btnGetProjects = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCompanies = new System.Windows.Forms.ComboBox();
            this.btnLoadCompanies = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLookupLists = new System.Windows.Forms.ComboBox();
            this.btnLoadLookupLists = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPortfolioLookupListEntries = new System.Windows.Forms.ComboBox();
            this.btnLoadPortfolioLookupListEntries = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cboProjectRFIWorkflowStates = new System.Windows.Forms.ComboBox();
            this.btnLoadProjectRFIWorkflowStates = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboRFIUDFs = new System.Windows.Forms.ComboBox();
            this.btnLoadRFIUDFs = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cboRFIReports = new System.Windows.Forms.ComboBox();
            this.btnLoadRFIReports = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cboRFIs = new System.Windows.Forms.ComboBox();
            this.btnLoadRFIs = new System.Windows.Forms.Button();
            this.btnLoadRFIsModifiedInLast10Minutes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOnBehalfOf = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.btnLoadUsers = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateRFIWithExternalFile
            // 
            this.btnCreateRFIWithExternalFile.Enabled = false;
            this.btnCreateRFIWithExternalFile.Location = new System.Drawing.Point(792, 64);
            this.btnCreateRFIWithExternalFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateRFIWithExternalFile.Name = "btnCreateRFIWithExternalFile";
            this.btnCreateRFIWithExternalFile.Size = new System.Drawing.Size(216, 28);
            this.btnCreateRFIWithExternalFile.TabIndex = 0;
            this.btnCreateRFIWithExternalFile.Text = "Create RFI With External File";
            this.btnCreateRFIWithExternalFile.UseVisualStyleBackColor = true;
            this.btnCreateRFIWithExternalFile.Click += new System.EventHandler(this.btnCreateRFIWithExternalFile_Click);
            // 
            // btnCreateRFIOnBehalfOfUser
            // 
            this.btnCreateRFIOnBehalfOfUser.Enabled = false;
            this.btnCreateRFIOnBehalfOfUser.Location = new System.Drawing.Point(336, 39);
            this.btnCreateRFIOnBehalfOfUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateRFIOnBehalfOfUser.Name = "btnCreateRFIOnBehalfOfUser";
            this.btnCreateRFIOnBehalfOfUser.Size = new System.Drawing.Size(212, 28);
            this.btnCreateRFIOnBehalfOfUser.TabIndex = 1;
            this.btnCreateRFIOnBehalfOfUser.Text = "Create RFI On Behalf of User";
            this.btnCreateRFIOnBehalfOfUser.UseVisualStyleBackColor = true;
            this.btnCreateRFIOnBehalfOfUser.Click += new System.EventHandler(this.btnCreateRFIOnBehalfOfUser_Click);
            // 
            // btnCreateRFIOnBehalfOfContact
            // 
            this.btnCreateRFIOnBehalfOfContact.Enabled = false;
            this.btnCreateRFIOnBehalfOfContact.Location = new System.Drawing.Point(556, 39);
            this.btnCreateRFIOnBehalfOfContact.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateRFIOnBehalfOfContact.Name = "btnCreateRFIOnBehalfOfContact";
            this.btnCreateRFIOnBehalfOfContact.Size = new System.Drawing.Size(240, 28);
            this.btnCreateRFIOnBehalfOfContact.TabIndex = 2;
            this.btnCreateRFIOnBehalfOfContact.Text = "Create RFI On Behalf of Contact";
            this.btnCreateRFIOnBehalfOfContact.UseVisualStyleBackColor = true;
            this.btnCreateRFIOnBehalfOfContact.Click += new System.EventHandler(this.btnCreateRFIOnBehalfOfContact_Click);
            // 
            // btnCreateRFIOnBehalfOfContactID
            // 
            this.btnCreateRFIOnBehalfOfContactID.Enabled = false;
            this.btnCreateRFIOnBehalfOfContactID.Location = new System.Drawing.Point(804, 39);
            this.btnCreateRFIOnBehalfOfContactID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateRFIOnBehalfOfContactID.Name = "btnCreateRFIOnBehalfOfContactID";
            this.btnCreateRFIOnBehalfOfContactID.Size = new System.Drawing.Size(244, 28);
            this.btnCreateRFIOnBehalfOfContactID.TabIndex = 3;
            this.btnCreateRFIOnBehalfOfContactID.Text = "Create RFI On Behalf of ContactID";
            this.btnCreateRFIOnBehalfOfContactID.UseVisualStyleBackColor = true;
            this.btnCreateRFIOnBehalfOfContactID.Click += new System.EventHandler(this.btnCreateRFIOnBehalfOfContactID_Click);
            // 
            // btnCreateRFIWithUDFs
            // 
            this.btnCreateRFIWithUDFs.Enabled = false;
            this.btnCreateRFIWithUDFs.Location = new System.Drawing.Point(792, 28);
            this.btnCreateRFIWithUDFs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateRFIWithUDFs.Name = "btnCreateRFIWithUDFs";
            this.btnCreateRFIWithUDFs.Size = new System.Drawing.Size(216, 28);
            this.btnCreateRFIWithUDFs.TabIndex = 5;
            this.btnCreateRFIWithUDFs.Text = "Create RFI with UDFs";
            this.btnCreateRFIWithUDFs.UseVisualStyleBackColor = true;
            this.btnCreateRFIWithUDFs.Click += new System.EventHandler(this.btnCreateRFIWithUDFs_Click);
            // 
            // btnGetPortfolios
            // 
            this.btnGetPortfolios.Location = new System.Drawing.Point(283, 192);
            this.btnGetPortfolios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetPortfolios.Name = "btnGetPortfolios";
            this.btnGetPortfolios.Size = new System.Drawing.Size(59, 28);
            this.btnGetPortfolios.TabIndex = 3;
            this.btnGetPortfolios.Text = "Load";
            this.btnGetPortfolios.UseVisualStyleBackColor = true;
            this.btnGetPortfolios.Click += new System.EventHandler(this.btnGetPortfolios_Click);
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(16, 112);
            this.txtClientID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(320, 22);
            this.txtClientID.TabIndex = 1;
            this.txtClientID.TextChanged += new System.EventHandler(this.CredentialTextBoxChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPromptUser);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtApplicationName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtClientSecret);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtClientID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1067, 144);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credentials";
            // 
            // chkPromptUser
            // 
            this.chkPromptUser.AutoSize = true;
            this.chkPromptUser.Location = new System.Drawing.Point(352, 56);
            this.chkPromptUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPromptUser.Name = "chkPromptUser";
            this.chkPromptUser.Size = new System.Drawing.Size(84, 20);
            this.chkPromptUser.TabIndex = 14;
            this.chkPromptUser.Text = "As User?";
            this.chkPromptUser.UseVisualStyleBackColor = true;
            this.chkPromptUser.CheckedChanged += new System.EventHandler(this.chkPromptUser_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Application Name";
            // 
            // txtApplicationName
            // 
            this.txtApplicationName.Location = new System.Drawing.Point(16, 54);
            this.txtApplicationName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new System.Drawing.Size(320, 22);
            this.txtApplicationName.TabIndex = 0;
            this.txtApplicationName.TextChanged += new System.EventHandler(this.CredentialTextBoxChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Consumer Secret";
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Location = new System.Drawing.Point(345, 112);
            this.txtClientSecret.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.PasswordChar = '*';
            this.txtClientSecret.Size = new System.Drawing.Size(320, 22);
            this.txtClientSecret.TabIndex = 2;
            this.txtClientSecret.TextChanged += new System.EventHandler(this.CredentialTextBoxChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Consumer Key";
            // 
            // cboPortfolios
            // 
            this.cboPortfolios.DisplayMember = "Name";
            this.cboPortfolios.FormattingEnabled = true;
            this.cboPortfolios.Location = new System.Drawing.Point(16, 194);
            this.cboPortfolios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPortfolios.Name = "cboPortfolios";
            this.cboPortfolios.Size = new System.Drawing.Size(257, 24);
            this.cboPortfolios.TabIndex = 4;
            this.cboPortfolios.ValueMember = "PortfolioID";
            this.cboPortfolios.SelectedIndexChanged += new System.EventHandler(this.cboPortfolios_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Portfolios";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Projects";
            // 
            // cboProjects
            // 
            this.cboProjects.DisplayMember = "Name";
            this.cboProjects.FormattingEnabled = true;
            this.cboProjects.Location = new System.Drawing.Point(349, 194);
            this.cboProjects.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Size = new System.Drawing.Size(257, 24);
            this.cboProjects.TabIndex = 6;
            this.cboProjects.ValueMember = "PortfolioID";
            this.cboProjects.SelectedIndexChanged += new System.EventHandler(this.cboProjects_SelectedIndexChanged);
            // 
            // btnGetProjects
            // 
            this.btnGetProjects.Enabled = false;
            this.btnGetProjects.Location = new System.Drawing.Point(616, 192);
            this.btnGetProjects.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetProjects.Name = "btnGetProjects";
            this.btnGetProjects.Size = new System.Drawing.Size(59, 28);
            this.btnGetProjects.TabIndex = 5;
            this.btnGetProjects.Text = "Load";
            this.btnGetProjects.UseVisualStyleBackColor = true;
            this.btnGetProjects.Click += new System.EventHandler(this.btnGetProjects_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Companies";
            // 
            // cboCompanies
            // 
            this.cboCompanies.DisplayMember = "Name";
            this.cboCompanies.FormattingEnabled = true;
            this.cboCompanies.Location = new System.Drawing.Point(16, 261);
            this.cboCompanies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCompanies.Name = "cboCompanies";
            this.cboCompanies.Size = new System.Drawing.Size(257, 24);
            this.cboCompanies.TabIndex = 19;
            this.cboCompanies.ValueMember = "CompanyID";
            // 
            // btnLoadCompanies
            // 
            this.btnLoadCompanies.Enabled = false;
            this.btnLoadCompanies.Location = new System.Drawing.Point(283, 261);
            this.btnLoadCompanies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadCompanies.Name = "btnLoadCompanies";
            this.btnLoadCompanies.Size = new System.Drawing.Size(59, 28);
            this.btnLoadCompanies.TabIndex = 18;
            this.btnLoadCompanies.Text = "Load";
            this.btnLoadCompanies.UseVisualStyleBackColor = true;
            this.btnLoadCompanies.Click += new System.EventHandler(this.btnLoadCompanies_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 302);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Lookup Lists";
            // 
            // cboLookupLists
            // 
            this.cboLookupLists.DisplayMember = "Name";
            this.cboLookupLists.FormattingEnabled = true;
            this.cboLookupLists.Location = new System.Drawing.Point(16, 321);
            this.cboLookupLists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLookupLists.Name = "cboLookupLists";
            this.cboLookupLists.Size = new System.Drawing.Size(257, 24);
            this.cboLookupLists.TabIndex = 22;
            this.cboLookupLists.ValueMember = "Section";
            this.cboLookupLists.SelectedIndexChanged += new System.EventHandler(this.cboLookupLists_SelectedIndexChanged);
            // 
            // btnLoadLookupLists
            // 
            this.btnLoadLookupLists.Enabled = false;
            this.btnLoadLookupLists.Location = new System.Drawing.Point(283, 321);
            this.btnLoadLookupLists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadLookupLists.Name = "btnLoadLookupLists";
            this.btnLoadLookupLists.Size = new System.Drawing.Size(59, 28);
            this.btnLoadLookupLists.TabIndex = 21;
            this.btnLoadLookupLists.Text = "Load";
            this.btnLoadLookupLists.UseVisualStyleBackColor = true;
            this.btnLoadLookupLists.Click += new System.EventHandler(this.btnLoadLookupLists_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 304);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Portfolio Lookup List Entries";
            // 
            // cboPortfolioLookupListEntries
            // 
            this.cboPortfolioLookupListEntries.DisplayMember = "Description";
            this.cboPortfolioLookupListEntries.FormattingEnabled = true;
            this.cboPortfolioLookupListEntries.Location = new System.Drawing.Point(349, 324);
            this.cboPortfolioLookupListEntries.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPortfolioLookupListEntries.Name = "cboPortfolioLookupListEntries";
            this.cboPortfolioLookupListEntries.Size = new System.Drawing.Size(257, 24);
            this.cboPortfolioLookupListEntries.TabIndex = 25;
            this.cboPortfolioLookupListEntries.ValueMember = "LookupListID";
            // 
            // btnLoadPortfolioLookupListEntries
            // 
            this.btnLoadPortfolioLookupListEntries.Enabled = false;
            this.btnLoadPortfolioLookupListEntries.Location = new System.Drawing.Point(616, 324);
            this.btnLoadPortfolioLookupListEntries.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadPortfolioLookupListEntries.Name = "btnLoadPortfolioLookupListEntries";
            this.btnLoadPortfolioLookupListEntries.Size = new System.Drawing.Size(59, 28);
            this.btnLoadPortfolioLookupListEntries.TabIndex = 24;
            this.btnLoadPortfolioLookupListEntries.Text = "Load";
            this.btnLoadPortfolioLookupListEntries.UseVisualStyleBackColor = true;
            this.btnLoadPortfolioLookupListEntries.Click += new System.EventHandler(this.btnLoadPortfolioLookupListEntries_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 244);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Project RFI Workflow States";
            // 
            // cboProjectRFIWorkflowStates
            // 
            this.cboProjectRFIWorkflowStates.DisplayMember = "Name";
            this.cboProjectRFIWorkflowStates.FormattingEnabled = true;
            this.cboProjectRFIWorkflowStates.Location = new System.Drawing.Point(349, 263);
            this.cboProjectRFIWorkflowStates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboProjectRFIWorkflowStates.Name = "cboProjectRFIWorkflowStates";
            this.cboProjectRFIWorkflowStates.Size = new System.Drawing.Size(257, 24);
            this.cboProjectRFIWorkflowStates.TabIndex = 28;
            this.cboProjectRFIWorkflowStates.ValueMember = "RecordId";
            // 
            // btnLoadProjectRFIWorkflowStates
            // 
            this.btnLoadProjectRFIWorkflowStates.Enabled = false;
            this.btnLoadProjectRFIWorkflowStates.Location = new System.Drawing.Point(616, 263);
            this.btnLoadProjectRFIWorkflowStates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadProjectRFIWorkflowStates.Name = "btnLoadProjectRFIWorkflowStates";
            this.btnLoadProjectRFIWorkflowStates.Size = new System.Drawing.Size(59, 28);
            this.btnLoadProjectRFIWorkflowStates.TabIndex = 27;
            this.btnLoadProjectRFIWorkflowStates.Text = "Load";
            this.btnLoadProjectRFIWorkflowStates.UseVisualStyleBackColor = true;
            this.btnLoadProjectRFIWorkflowStates.Click += new System.EventHandler(this.btnLoadProjectRFIWorkflowStates_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(683, 246);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "RFI UDFs";
            // 
            // cboRFIUDFs
            // 
            this.cboRFIUDFs.DisplayMember = "DBName";
            this.cboRFIUDFs.FormattingEnabled = true;
            this.cboRFIUDFs.Location = new System.Drawing.Point(683, 266);
            this.cboRFIUDFs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboRFIUDFs.Name = "cboRFIUDFs";
            this.cboRFIUDFs.Size = new System.Drawing.Size(257, 24);
            this.cboRFIUDFs.TabIndex = 31;
            this.cboRFIUDFs.ValueMember = "DBName";
            // 
            // btnLoadRFIUDFs
            // 
            this.btnLoadRFIUDFs.Enabled = false;
            this.btnLoadRFIUDFs.Location = new System.Drawing.Point(949, 266);
            this.btnLoadRFIUDFs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadRFIUDFs.Name = "btnLoadRFIUDFs";
            this.btnLoadRFIUDFs.Size = new System.Drawing.Size(59, 28);
            this.btnLoadRFIUDFs.TabIndex = 30;
            this.btnLoadRFIUDFs.Text = "Load";
            this.btnLoadRFIUDFs.UseVisualStyleBackColor = true;
            this.btnLoadRFIUDFs.Click += new System.EventHandler(this.btnLoadRFIUDFs_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(683, 306);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "RFI Reports";
            // 
            // cboRFIReports
            // 
            this.cboRFIReports.DisplayMember = "DisplayDescription";
            this.cboRFIReports.FormattingEnabled = true;
            this.cboRFIReports.Location = new System.Drawing.Point(683, 326);
            this.cboRFIReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboRFIReports.Name = "cboRFIReports";
            this.cboRFIReports.Size = new System.Drawing.Size(257, 24);
            this.cboRFIReports.TabIndex = 34;
            this.cboRFIReports.ValueMember = "ID";
            // 
            // btnLoadRFIReports
            // 
            this.btnLoadRFIReports.Enabled = false;
            this.btnLoadRFIReports.Location = new System.Drawing.Point(949, 326);
            this.btnLoadRFIReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadRFIReports.Name = "btnLoadRFIReports";
            this.btnLoadRFIReports.Size = new System.Drawing.Size(59, 28);
            this.btnLoadRFIReports.TabIndex = 33;
            this.btnLoadRFIReports.Text = "Load";
            this.btnLoadRFIReports.UseVisualStyleBackColor = true;
            this.btnLoadRFIReports.Click += new System.EventHandler(this.btnLoadRFIReports_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 28);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 16);
            this.label12.TabIndex = 38;
            this.label12.Text = "RFIs";
            // 
            // cboRFIs
            // 
            this.cboRFIs.DisplayMember = "Number";
            this.cboRFIs.FormattingEnabled = true;
            this.cboRFIs.Location = new System.Drawing.Point(8, 48);
            this.cboRFIs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboRFIs.Name = "cboRFIs";
            this.cboRFIs.Size = new System.Drawing.Size(257, 24);
            this.cboRFIs.TabIndex = 37;
            this.cboRFIs.ValueMember = "RFI_ID";
            // 
            // btnLoadRFIs
            // 
            this.btnLoadRFIs.Enabled = false;
            this.btnLoadRFIs.Location = new System.Drawing.Point(275, 48);
            this.btnLoadRFIs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadRFIs.Name = "btnLoadRFIs";
            this.btnLoadRFIs.Size = new System.Drawing.Size(97, 28);
            this.btnLoadRFIs.TabIndex = 36;
            this.btnLoadRFIs.Text = "Load 10";
            this.btnLoadRFIs.UseVisualStyleBackColor = true;
            this.btnLoadRFIs.Click += new System.EventHandler(this.btnLoadRFIs_Click);
            // 
            // btnLoadRFIsModifiedInLast10Minutes
            // 
            this.btnLoadRFIsModifiedInLast10Minutes.Enabled = false;
            this.btnLoadRFIsModifiedInLast10Minutes.Location = new System.Drawing.Point(380, 48);
            this.btnLoadRFIsModifiedInLast10Minutes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadRFIsModifiedInLast10Minutes.Name = "btnLoadRFIsModifiedInLast10Minutes";
            this.btnLoadRFIsModifiedInLast10Minutes.Size = new System.Drawing.Size(311, 28);
            this.btnLoadRFIsModifiedInLast10Minutes.TabIndex = 39;
            this.btnLoadRFIsModifiedInLast10Minutes.Text = "Find RFIs Modified In Past 10 Minutes";
            this.btnLoadRFIsModifiedInLast10Minutes.UseVisualStyleBackColor = true;
            this.btnLoadRFIsModifiedInLast10Minutes.Click += new System.EventHandler(this.btnLoadRFIsModifiedInLast10Minutes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtOnBehalfOf);
            this.groupBox2.Controls.Add(this.btnCreateRFIOnBehalfOfUser);
            this.groupBox2.Controls.Add(this.btnCreateRFIOnBehalfOfContact);
            this.groupBox2.Controls.Add(this.btnCreateRFIOnBehalfOfContactID);
            this.groupBox2.Location = new System.Drawing.Point(1, 470);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1065, 84);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "On-Behalf Of";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 16);
            this.label13.TabIndex = 15;
            this.label13.Text = "On-Behalf-Of Identifier";
            // 
            // txtOnBehalfOf
            // 
            this.txtOnBehalfOf.Location = new System.Drawing.Point(7, 43);
            this.txtOnBehalfOf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOnBehalfOf.Name = "txtOnBehalfOf";
            this.txtOnBehalfOf.Size = new System.Drawing.Size(320, 22);
            this.txtOnBehalfOf.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboRFIs);
            this.groupBox3.Controls.Add(this.btnLoadRFIs);
            this.groupBox3.Controls.Add(this.btnLoadRFIsModifiedInLast10Minutes);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.btnCreateRFIWithUDFs);
            this.groupBox3.Controls.Add(this.btnCreateRFIWithExternalFile);
            this.groupBox3.Location = new System.Drawing.Point(0, 357);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1067, 106);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Records";
            // 
            // cboUsers
            // 
            this.cboUsers.DisplayMember = "UserName";
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(683, 192);
            this.cboUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(257, 24);
            this.cboUsers.TabIndex = 43;
            this.cboUsers.ValueMember = "ID";
            // 
            // btnLoadUsers
            // 
            this.btnLoadUsers.Enabled = false;
            this.btnLoadUsers.Location = new System.Drawing.Point(949, 192);
            this.btnLoadUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadUsers.Name = "btnLoadUsers";
            this.btnLoadUsers.Size = new System.Drawing.Size(59, 28);
            this.btnLoadUsers.TabIndex = 42;
            this.btnLoadUsers.Text = "Load";
            this.btnLoadUsers.UseVisualStyleBackColor = true;
            this.btnLoadUsers.Click += new System.EventHandler(this.btnLoadUsers_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(683, 172);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 16);
            this.label15.TabIndex = 44;
            this.label15.Text = "Users";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboUsers);
            this.Controls.Add(this.btnLoadUsers);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboRFIReports);
            this.Controls.Add(this.btnLoadRFIReports);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboRFIUDFs);
            this.Controls.Add(this.btnLoadRFIUDFs);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboProjectRFIWorkflowStates);
            this.Controls.Add(this.btnLoadProjectRFIWorkflowStates);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboPortfolioLookupListEntries);
            this.Controls.Add(this.btnLoadPortfolioLookupListEntries);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboLookupLists);
            this.Controls.Add(this.btnLoadLookupLists);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCompanies);
            this.Controls.Add(this.btnLoadCompanies);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboProjects);
            this.Controls.Add(this.btnGetProjects);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPortfolios);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGetPortfolios);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "ProjectSight Sample Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateRFIWithExternalFile;
        private System.Windows.Forms.Button btnCreateRFIOnBehalfOfUser;
        private System.Windows.Forms.Button btnCreateRFIOnBehalfOfContact;
        private System.Windows.Forms.Button btnCreateRFIOnBehalfOfContactID;
        private System.Windows.Forms.Button btnCreateRFIWithUDFs;
        private System.Windows.Forms.Button btnGetPortfolios;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApplicationName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPortfolios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProjects;
        private System.Windows.Forms.Button btnGetProjects;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCompanies;
        private System.Windows.Forms.Button btnLoadCompanies;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboLookupLists;
        private System.Windows.Forms.Button btnLoadLookupLists;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPortfolioLookupListEntries;
        private System.Windows.Forms.Button btnLoadPortfolioLookupListEntries;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboProjectRFIWorkflowStates;
        private System.Windows.Forms.Button btnLoadProjectRFIWorkflowStates;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboRFIUDFs;
        private System.Windows.Forms.Button btnLoadRFIUDFs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboRFIReports;
        private System.Windows.Forms.Button btnLoadRFIReports;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboRFIs;
        private System.Windows.Forms.Button btnLoadRFIs;
        private System.Windows.Forms.Button btnLoadRFIsModifiedInLast10Minutes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOnBehalfOf;
        private System.Windows.Forms.CheckBox chkPromptUser;
        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.Button btnLoadUsers;
        private System.Windows.Forms.Label label15;
    }
}

