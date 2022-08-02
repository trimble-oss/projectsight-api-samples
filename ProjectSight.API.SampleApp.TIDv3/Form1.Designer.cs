namespace ProjectSight.API.SampleApp.TIDv3
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
            this.cmdCreateRFIWithExternalFile = new System.Windows.Forms.Button();
            this.cmdCreateRFIOnBehalfOfUser = new System.Windows.Forms.Button();
            this.cmdCreateRFIOnBehalfOfContact = new System.Windows.Forms.Button();
            this.cmdCreateRFIOnBehalfOfContactID = new System.Windows.Forms.Button();
            this.cmdCreateRFIOnBehalfOfPlainText = new System.Windows.Forms.Button();
            this.cmdProcessRFIWithUDFs = new System.Windows.Forms.Button();
            this.cmdCreateMeetingForToday = new System.Windows.Forms.Button();
            this.btnGetPortfolios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdCreateRFIWithExternalFile
            // 
            this.cmdCreateRFIWithExternalFile.Location = new System.Drawing.Point(40, 36);
            this.cmdCreateRFIWithExternalFile.Name = "cmdCreateRFIWithExternalFile";
            this.cmdCreateRFIWithExternalFile.Size = new System.Drawing.Size(288, 23);
            this.cmdCreateRFIWithExternalFile.TabIndex = 0;
            this.cmdCreateRFIWithExternalFile.Text = "Create RFI With External File";
            this.cmdCreateRFIWithExternalFile.UseVisualStyleBackColor = true;
            this.cmdCreateRFIWithExternalFile.Click += new System.EventHandler(this.cmdCreateRFIWithExternalFile_Click);
            // 
            // cmdCreateRFIOnBehalfOfUser
            // 
            this.cmdCreateRFIOnBehalfOfUser.Location = new System.Drawing.Point(40, 80);
            this.cmdCreateRFIOnBehalfOfUser.Name = "cmdCreateRFIOnBehalfOfUser";
            this.cmdCreateRFIOnBehalfOfUser.Size = new System.Drawing.Size(288, 23);
            this.cmdCreateRFIOnBehalfOfUser.TabIndex = 1;
            this.cmdCreateRFIOnBehalfOfUser.Text = "Create RFI On Behalf of User";
            this.cmdCreateRFIOnBehalfOfUser.UseVisualStyleBackColor = true;
            this.cmdCreateRFIOnBehalfOfUser.Click += new System.EventHandler(this.cmdCreateRFIOnBehalfOfUser_Click);
            // 
            // cmdCreateRFIOnBehalfOfContact
            // 
            this.cmdCreateRFIOnBehalfOfContact.Location = new System.Drawing.Point(340, 80);
            this.cmdCreateRFIOnBehalfOfContact.Name = "cmdCreateRFIOnBehalfOfContact";
            this.cmdCreateRFIOnBehalfOfContact.Size = new System.Drawing.Size(288, 23);
            this.cmdCreateRFIOnBehalfOfContact.TabIndex = 2;
            this.cmdCreateRFIOnBehalfOfContact.Text = "Create RFI On Behalf of Contact";
            this.cmdCreateRFIOnBehalfOfContact.UseVisualStyleBackColor = true;
            this.cmdCreateRFIOnBehalfOfContact.Click += new System.EventHandler(this.cmdCreateRFIOnBehalfOfContact_Click);
            // 
            // cmdCreateRFIOnBehalfOfContactID
            // 
            this.cmdCreateRFIOnBehalfOfContactID.Location = new System.Drawing.Point(40, 120);
            this.cmdCreateRFIOnBehalfOfContactID.Name = "cmdCreateRFIOnBehalfOfContactID";
            this.cmdCreateRFIOnBehalfOfContactID.Size = new System.Drawing.Size(288, 23);
            this.cmdCreateRFIOnBehalfOfContactID.TabIndex = 3;
            this.cmdCreateRFIOnBehalfOfContactID.Text = "Create RFI On Behalf of ContactID";
            this.cmdCreateRFIOnBehalfOfContactID.UseVisualStyleBackColor = true;
            this.cmdCreateRFIOnBehalfOfContactID.Click += new System.EventHandler(this.cmdCreateRFIOnBehalfOfContactID_Click);
            // 
            // cmdCreateRFIOnBehalfOfPlainText
            // 
            this.cmdCreateRFIOnBehalfOfPlainText.Location = new System.Drawing.Point(340, 120);
            this.cmdCreateRFIOnBehalfOfPlainText.Name = "cmdCreateRFIOnBehalfOfPlainText";
            this.cmdCreateRFIOnBehalfOfPlainText.Size = new System.Drawing.Size(288, 23);
            this.cmdCreateRFIOnBehalfOfPlainText.TabIndex = 4;
            this.cmdCreateRFIOnBehalfOfPlainText.Text = "Create RFI On Behalf of Plain Text";
            this.cmdCreateRFIOnBehalfOfPlainText.UseVisualStyleBackColor = true;
            this.cmdCreateRFIOnBehalfOfPlainText.Click += new System.EventHandler(this.cmdCreateRFIOnBehalfOfPlainText_Click);
            // 
            // cmdProcessRFIWithUDFs
            // 
            this.cmdProcessRFIWithUDFs.Location = new System.Drawing.Point(340, 36);
            this.cmdProcessRFIWithUDFs.Name = "cmdProcessRFIWithUDFs";
            this.cmdProcessRFIWithUDFs.Size = new System.Drawing.Size(288, 23);
            this.cmdProcessRFIWithUDFs.TabIndex = 5;
            this.cmdProcessRFIWithUDFs.Text = "Process RFI with UDFs";
            this.cmdProcessRFIWithUDFs.UseVisualStyleBackColor = true;
            this.cmdProcessRFIWithUDFs.Click += new System.EventHandler(this.cmdProcessRFIWithUDFs_Click);
            // 
            // cmdCreateMeetingForToday
            // 
            this.cmdCreateMeetingForToday.Location = new System.Drawing.Point(40, 164);
            this.cmdCreateMeetingForToday.Name = "cmdCreateMeetingForToday";
            this.cmdCreateMeetingForToday.Size = new System.Drawing.Size(288, 23);
            this.cmdCreateMeetingForToday.TabIndex = 6;
            this.cmdCreateMeetingForToday.Text = "Create Meeting for Today";
            this.cmdCreateMeetingForToday.UseVisualStyleBackColor = true;
            this.cmdCreateMeetingForToday.Click += new System.EventHandler(this.cmdCreateMeetingForToday_Click);
            // 
            // btnGetPortfolios
            // 
            this.btnGetPortfolios.Location = new System.Drawing.Point(340, 164);
            this.btnGetPortfolios.Name = "btnGetPortfolios";
            this.btnGetPortfolios.Size = new System.Drawing.Size(288, 23);
            this.btnGetPortfolios.TabIndex = 7;
            this.btnGetPortfolios.Text = "Get Portfolios";
            this.btnGetPortfolios.UseVisualStyleBackColor = true;
            this.btnGetPortfolios.Click += new System.EventHandler(this.btnGetPortfolios_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetPortfolios);
            this.Controls.Add(this.cmdCreateMeetingForToday);
            this.Controls.Add(this.cmdProcessRFIWithUDFs);
            this.Controls.Add(this.cmdCreateRFIOnBehalfOfPlainText);
            this.Controls.Add(this.cmdCreateRFIOnBehalfOfContactID);
            this.Controls.Add(this.cmdCreateRFIOnBehalfOfContact);
            this.Controls.Add(this.cmdCreateRFIOnBehalfOfUser);
            this.Controls.Add(this.cmdCreateRFIWithExternalFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCreateRFIWithExternalFile;
        private System.Windows.Forms.Button cmdCreateRFIOnBehalfOfUser;
        private System.Windows.Forms.Button cmdCreateRFIOnBehalfOfContact;
        private System.Windows.Forms.Button cmdCreateRFIOnBehalfOfContactID;
        private System.Windows.Forms.Button cmdCreateRFIOnBehalfOfPlainText;
        private System.Windows.Forms.Button cmdProcessRFIWithUDFs;
        private System.Windows.Forms.Button cmdCreateMeetingForToday;
        private System.Windows.Forms.Button btnGetPortfolios;
    }
}

