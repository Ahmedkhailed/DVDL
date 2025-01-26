namespace DrivingLicenseManagement
{
    partial class frmNewInternationalLicenseApplication
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
            this.lbUser = new System.Windows.Forms.Label();
            this.linkLabelShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssue = new Guna.UI2.WinForms.Guna2Button();
            this.filterDriverLicenseInfo1 = new DrivingLicenseManagement.FilterDriverLicenseInfo();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lbILApplicationID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbFees = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbLocalLicenseID = new System.Windows.Forms.Label();
            this.b = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lbExprationDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.lbILLicenseID = new System.Windows.Forms.Label();
            this.Application = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.Application.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbUser.AutoSize = true;
            this.lbUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.Brown;
            this.lbUser.Location = new System.Drawing.Point(396, 6);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(480, 36);
            this.lbUser.TabIndex = 3;
            this.lbUser.Text = "International License Application";
            // 
            // linkLabelShowLicenseHistory
            // 
            this.linkLabelShowLicenseHistory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabelShowLicenseHistory.AutoSize = true;
            this.linkLabelShowLicenseHistory.Enabled = false;
            this.linkLabelShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowLicenseHistory.Location = new System.Drawing.Point(38, 819);
            this.linkLabelShowLicenseHistory.Name = "linkLabelShowLicenseHistory";
            this.linkLabelShowLicenseHistory.Size = new System.Drawing.Size(181, 18);
            this.linkLabelShowLicenseHistory.TabIndex = 159;
            this.linkLabelShowLicenseHistory.TabStop = true;
            this.linkLabelShowLicenseHistory.Text = "Show Licenses History";
            this.linkLabelShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseHistory_LinkClicked);
            // 
            // linkLabelShowLicenseInfo
            // 
            this.linkLabelShowLicenseInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabelShowLicenseInfo.AutoSize = true;
            this.linkLabelShowLicenseInfo.Enabled = false;
            this.linkLabelShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowLicenseInfo.Location = new System.Drawing.Point(250, 819);
            this.linkLabelShowLicenseInfo.Name = "linkLabelShowLicenseInfo";
            this.linkLabelShowLicenseInfo.Size = new System.Drawing.Size(155, 18);
            this.linkLabelShowLicenseInfo.TabIndex = 160;
            this.linkLabelShowLicenseInfo.TabStop = true;
            this.linkLabelShowLicenseInfo.Text = "Show Licenses Info";
            this.linkLabelShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseInfo_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Animated = true;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::DrivingLicenseManagement.Properties.Resources.close__2_;
            this.btnClose.Location = new System.Drawing.Point(1076, 812);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(97, 32);
            this.btnClose.TabIndex = 158;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnIssue.Animated = true;
            this.btnIssue.CheckedState.Parent = this.btnIssue;
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.CustomImages.Parent = this.btnIssue;
            this.btnIssue.Enabled = false;
            this.btnIssue.FillColor = System.Drawing.Color.Transparent;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIssue.ForeColor = System.Drawing.Color.Black;
            this.btnIssue.HoverState.Parent = this.btnIssue;
            this.btnIssue.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.btnIssue.Location = new System.Drawing.Point(1179, 812);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.ShadowDecoration.Parent = this.btnIssue;
            this.btnIssue.Size = new System.Drawing.Size(97, 32);
            this.btnIssue.TabIndex = 157;
            this.btnIssue.Text = "Issue";
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // filterDriverLicenseInfo1
            // 
            this.filterDriverLicenseInfo1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filterDriverLicenseInfo1.FilterEnabled = true;
            this.filterDriverLicenseInfo1.Location = new System.Drawing.Point(7, 45);
            this.filterDriverLicenseInfo1.Name = "filterDriverLicenseInfo1";
            this.filterDriverLicenseInfo1.Size = new System.Drawing.Size(1269, 523);
            this.filterDriverLicenseInfo1.TabIndex = 161;
            this.filterDriverLicenseInfo1.LicenseIDSelected += new DrivingLicenseManagement.FilterDriverLicenseInfo.LicenseIDSelectedEventHandler(this.filterDriverLicenseInfo1_LicenseIDSelected);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 18);
            this.label8.TabIndex = 148;
            this.label8.Text = "I.L.Applicaion ID:";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox7.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.pictureBox7.Location = new System.Drawing.Point(164, 61);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 149;
            this.pictureBox7.TabStop = false;
            // 
            // lbILApplicationID
            // 
            this.lbILApplicationID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbILApplicationID.AutoSize = true;
            this.lbILApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbILApplicationID.Location = new System.Drawing.Point(191, 60);
            this.lbILApplicationID.Name = "lbILApplicationID";
            this.lbILApplicationID.Size = new System.Drawing.Size(45, 18);
            this.lbILApplicationID.TabIndex = 150;
            this.lbILApplicationID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 151;
            this.label2.Text = "Applcaion Date:";
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.Location = new System.Drawing.Point(191, 103);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(45, 18);
            this.lbApplicationDate.TabIndex = 152;
            this.lbApplicationDate.Text = "[???]";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 153;
            this.label4.Text = "Fees:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::DrivingLicenseManagement.Properties.Resources.money;
            this.pictureBox2.Location = new System.Drawing.Point(163, 190);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 154;
            this.pictureBox2.TabStop = false;
            // 
            // lbFees
            // 
            this.lbFees.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbFees.AutoSize = true;
            this.lbFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFees.Location = new System.Drawing.Point(190, 189);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(45, 18);
            this.lbFees.TabIndex = 155;
            this.lbFees.Text = "[???]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox8.Image = global::DrivingLicenseManagement.Properties.Resources.calendar__1_;
            this.pictureBox8.Location = new System.Drawing.Point(163, 104);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(16, 16);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 156;
            this.pictureBox8.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 18);
            this.label13.TabIndex = 157;
            this.label13.Text = "Issue Date:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox6.Image = global::DrivingLicenseManagement.Properties.Resources.calendar__1_;
            this.pictureBox6.Location = new System.Drawing.Point(163, 147);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 158;
            this.pictureBox6.TabStop = false;
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueDate.Location = new System.Drawing.Point(190, 146);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(45, 18);
            this.lbIssueDate.TabIndex = 159;
            this.lbIssueDate.Text = "[???]";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(546, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 18);
            this.label11.TabIndex = 160;
            this.label11.Text = "Created By:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox5.Image = global::DrivingLicenseManagement.Properties.Resources.user__3_;
            this.pictureBox5.Location = new System.Drawing.Point(706, 189);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 161;
            this.pictureBox5.TabStop = false;
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(733, 188);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(45, 18);
            this.lbCreatedBy.TabIndex = 162;
            this.lbCreatedBy.Text = "[???]";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(546, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 163;
            this.label3.Text = "Local License ID:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox4.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.pictureBox4.Location = new System.Drawing.Point(706, 103);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 164;
            this.pictureBox4.TabStop = false;
            // 
            // lbLocalLicenseID
            // 
            this.lbLocalLicenseID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbLocalLicenseID.AutoSize = true;
            this.lbLocalLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalLicenseID.Location = new System.Drawing.Point(733, 102);
            this.lbLocalLicenseID.Name = "lbLocalLicenseID";
            this.lbLocalLicenseID.Size = new System.Drawing.Size(45, 18);
            this.lbLocalLicenseID.TabIndex = 165;
            this.lbLocalLicenseID.Text = "[???]";
            // 
            // b
            // 
            this.b.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.b.AutoSize = true;
            this.b.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b.Location = new System.Drawing.Point(546, 145);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(128, 18);
            this.b.TabIndex = 166;
            this.b.Text = "Expiration Date:";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox9.Image = global::DrivingLicenseManagement.Properties.Resources.calendar__1_;
            this.pictureBox9.Location = new System.Drawing.Point(707, 146);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(16, 16);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 167;
            this.pictureBox9.TabStop = false;
            // 
            // lbExprationDate
            // 
            this.lbExprationDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExprationDate.AutoSize = true;
            this.lbExprationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExprationDate.Location = new System.Drawing.Point(734, 145);
            this.lbExprationDate.Name = "lbExprationDate";
            this.lbExprationDate.Size = new System.Drawing.Size(45, 18);
            this.lbExprationDate.TabIndex = 168;
            this.lbExprationDate.Text = "[???]";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(546, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 18);
            this.label10.TabIndex = 169;
            this.label10.Text = "I.L.License ID:";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox10.Image = global::DrivingLicenseManagement.Properties.Resources.world;
            this.pictureBox10.Location = new System.Drawing.Point(706, 60);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(16, 16);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 170;
            this.pictureBox10.TabStop = false;
            // 
            // lbILLicenseID
            // 
            this.lbILLicenseID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbILLicenseID.AutoSize = true;
            this.lbILLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbILLicenseID.Location = new System.Drawing.Point(733, 59);
            this.lbILLicenseID.Name = "lbILLicenseID";
            this.lbILLicenseID.Size = new System.Drawing.Size(45, 18);
            this.lbILLicenseID.TabIndex = 171;
            this.lbILLicenseID.Text = "[???]";
            // 
            // Application
            // 
            this.Application.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Application.Controls.Add(this.lbILLicenseID);
            this.Application.Controls.Add(this.pictureBox10);
            this.Application.Controls.Add(this.label10);
            this.Application.Controls.Add(this.lbExprationDate);
            this.Application.Controls.Add(this.pictureBox9);
            this.Application.Controls.Add(this.b);
            this.Application.Controls.Add(this.lbLocalLicenseID);
            this.Application.Controls.Add(this.pictureBox4);
            this.Application.Controls.Add(this.label3);
            this.Application.Controls.Add(this.lbCreatedBy);
            this.Application.Controls.Add(this.pictureBox5);
            this.Application.Controls.Add(this.label11);
            this.Application.Controls.Add(this.lbIssueDate);
            this.Application.Controls.Add(this.pictureBox6);
            this.Application.Controls.Add(this.label13);
            this.Application.Controls.Add(this.pictureBox8);
            this.Application.Controls.Add(this.lbFees);
            this.Application.Controls.Add(this.pictureBox2);
            this.Application.Controls.Add(this.label4);
            this.Application.Controls.Add(this.lbApplicationDate);
            this.Application.Controls.Add(this.label2);
            this.Application.Controls.Add(this.lbILApplicationID);
            this.Application.Controls.Add(this.pictureBox7);
            this.Application.Controls.Add(this.label8);
            this.Application.Location = new System.Drawing.Point(12, 574);
            this.Application.Name = "Application";
            this.Application.Size = new System.Drawing.Size(1264, 232);
            this.Application.TabIndex = 162;
            this.Application.TabStop = false;
            this.Application.Text = "Application Basic Info";
            // 
            // frmNewInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1288, 850);
            this.Controls.Add(this.Application);
            this.Controls.Add(this.filterDriverLicenseInfo1);
            this.Controls.Add(this.linkLabelShowLicenseInfo);
            this.Controls.Add(this.linkLabelShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.lbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNewInternationalLicenseApplication";
            this.Text = "frmNewInternationalLicenseApplication";
            this.Load += new System.EventHandler(this.frmNewInternationalLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.Application.ResumeLayout(false);
            this.Application.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbUser;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnIssue;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseHistory;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseInfo;
        private FilterDriverLicenseInfo filterDriverLicenseInfo1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lbILApplicationID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lbLocalLicenseID;
        private System.Windows.Forms.Label b;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lbExprationDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label lbILLicenseID;
        private System.Windows.Forms.GroupBox Application;
    }
}