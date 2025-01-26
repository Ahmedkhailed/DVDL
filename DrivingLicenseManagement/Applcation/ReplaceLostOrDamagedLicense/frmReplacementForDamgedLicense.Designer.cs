namespace DrivingLicenseManagement
{
    partial class frmReplacementForDamagedLicense
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
            this.linkLabelNewShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssueReplacement = new Guna.UI2.WinForms.Guna2Button();
            this.groupBoxReplacementFor = new System.Windows.Forms.GroupBox();
            this.radioButtonLostLicense = new System.Windows.Forms.RadioButton();
            this.radioButtonDamagedLicense = new System.Windows.Forms.RadioButton();
            this.filterDriverLicenseInfo1 = new DrivingLicenseManagement.FilterDriverLicenseInfo();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbOldLicenseID = new System.Windows.Forms.Label();
            this.lbReplacedLicenseID = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label99 = new System.Windows.Forms.Label();
            this.l1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbApplcationFees = new System.Windows.Forms.Label();
            this.lbApplcationDate = new System.Windows.Forms.Label();
            this.lbRLAppplicationID = new System.Windows.Forms.Label();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxReplacementFor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabelNewShowLicenseInfo
            // 
            this.linkLabelNewShowLicenseInfo.AutoSize = true;
            this.linkLabelNewShowLicenseInfo.Enabled = false;
            this.linkLabelNewShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelNewShowLicenseInfo.Location = new System.Drawing.Point(250, 771);
            this.linkLabelNewShowLicenseInfo.Name = "linkLabelNewShowLicenseInfo";
            this.linkLabelNewShowLicenseInfo.Size = new System.Drawing.Size(193, 18);
            this.linkLabelNewShowLicenseInfo.TabIndex = 174;
            this.linkLabelNewShowLicenseInfo.TabStop = true;
            this.linkLabelNewShowLicenseInfo.Text = "Show New Licenses Info";
            this.linkLabelNewShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNewShowLicenseInfo_LinkClicked);
            // 
            // linkLabelShowLicenseHistory
            // 
            this.linkLabelShowLicenseHistory.AutoSize = true;
            this.linkLabelShowLicenseHistory.Enabled = false;
            this.linkLabelShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowLicenseHistory.Location = new System.Drawing.Point(38, 771);
            this.linkLabelShowLicenseHistory.Name = "linkLabelShowLicenseHistory";
            this.linkLabelShowLicenseHistory.Size = new System.Drawing.Size(181, 18);
            this.linkLabelShowLicenseHistory.TabIndex = 173;
            this.linkLabelShowLicenseHistory.TabStop = true;
            this.linkLabelShowLicenseHistory.Text = "Show Licenses History";
            this.linkLabelShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseHistory_LinkClicked);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Brown;
            this.lbTitle.Location = new System.Drawing.Point(391, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(507, 36);
            this.lbTitle.TabIndex = 169;
            this.lbTitle.Text = "Replacement for Damaged License";
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::DrivingLicenseManagement.Properties.Resources.close__2_;
            this.btnClose.Location = new System.Drawing.Point(984, 764);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(97, 32);
            this.btnClose.TabIndex = 172;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Animated = true;
            this.btnIssueReplacement.CheckedState.Parent = this.btnIssueReplacement;
            this.btnIssueReplacement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssueReplacement.CustomImages.Parent = this.btnIssueReplacement;
            this.btnIssueReplacement.Enabled = false;
            this.btnIssueReplacement.FillColor = System.Drawing.Color.Transparent;
            this.btnIssueReplacement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIssueReplacement.ForeColor = System.Drawing.Color.Black;
            this.btnIssueReplacement.HoverState.Parent = this.btnIssueReplacement;
            this.btnIssueReplacement.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.btnIssueReplacement.Location = new System.Drawing.Point(1087, 764);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.ShadowDecoration.Parent = this.btnIssueReplacement;
            this.btnIssueReplacement.Size = new System.Drawing.Size(189, 32);
            this.btnIssueReplacement.TabIndex = 171;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // groupBoxReplacementFor
            // 
            this.groupBoxReplacementFor.Controls.Add(this.radioButtonLostLicense);
            this.groupBoxReplacementFor.Controls.Add(this.radioButtonDamagedLicense);
            this.groupBoxReplacementFor.Location = new System.Drawing.Point(612, 53);
            this.groupBoxReplacementFor.Name = "groupBoxReplacementFor";
            this.groupBoxReplacementFor.Size = new System.Drawing.Size(360, 82);
            this.groupBoxReplacementFor.TabIndex = 176;
            this.groupBoxReplacementFor.TabStop = false;
            this.groupBoxReplacementFor.Text = "Replacement For:";
            // 
            // radioButtonLostLicense
            // 
            this.radioButtonLostLicense.AutoSize = true;
            this.radioButtonLostLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLostLicense.Location = new System.Drawing.Point(217, 30);
            this.radioButtonLostLicense.Name = "radioButtonLostLicense";
            this.radioButtonLostLicense.Size = new System.Drawing.Size(113, 22);
            this.radioButtonLostLicense.TabIndex = 1;
            this.radioButtonLostLicense.Text = "Lost License";
            this.radioButtonLostLicense.UseVisualStyleBackColor = true;
            this.radioButtonLostLicense.CheckedChanged += new System.EventHandler(this.radioButtonLostLicense_CheckedChanged);
            // 
            // radioButtonDamagedLicense
            // 
            this.radioButtonDamagedLicense.AutoSize = true;
            this.radioButtonDamagedLicense.Checked = true;
            this.radioButtonDamagedLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDamagedLicense.Location = new System.Drawing.Point(31, 30);
            this.radioButtonDamagedLicense.Name = "radioButtonDamagedLicense";
            this.radioButtonDamagedLicense.Size = new System.Drawing.Size(148, 22);
            this.radioButtonDamagedLicense.TabIndex = 0;
            this.radioButtonDamagedLicense.TabStop = true;
            this.radioButtonDamagedLicense.Text = "Dameged License";
            this.radioButtonDamagedLicense.UseVisualStyleBackColor = true;
            this.radioButtonDamagedLicense.CheckedChanged += new System.EventHandler(this.radioButtonDamagedLicense_CheckedChanged);
            // 
            // filterDriverLicenseInfo1
            // 
            this.filterDriverLicenseInfo1.FilterEnabled = true;
            this.filterDriverLicenseInfo1.Location = new System.Drawing.Point(10, 46);
            this.filterDriverLicenseInfo1.Name = "filterDriverLicenseInfo1";
            this.filterDriverLicenseInfo1.Size = new System.Drawing.Size(1269, 539);
            this.filterDriverLicenseInfo1.TabIndex = 170;
            this.filterDriverLicenseInfo1.LicenseIDSelected += new DrivingLicenseManagement.FilterDriverLicenseInfo.LicenseIDSelectedEventHandler(this.filterDriverLicenseInfo1_LicenseIDSelected);
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(987, 128);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(45, 18);
            this.lbCreatedBy.TabIndex = 164;
            this.lbCreatedBy.Text = "[???]";
            // 
            // lbOldLicenseID
            // 
            this.lbOldLicenseID.AutoSize = true;
            this.lbOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOldLicenseID.Location = new System.Drawing.Point(989, 81);
            this.lbOldLicenseID.Name = "lbOldLicenseID";
            this.lbOldLicenseID.Size = new System.Drawing.Size(45, 18);
            this.lbOldLicenseID.TabIndex = 162;
            this.lbOldLicenseID.Text = "[???]";
            // 
            // lbReplacedLicenseID
            // 
            this.lbReplacedLicenseID.AutoSize = true;
            this.lbReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReplacedLicenseID.Location = new System.Drawing.Point(989, 34);
            this.lbReplacedLicenseID.Name = "lbReplacedLicenseID";
            this.lbReplacedLicenseID.Size = new System.Drawing.Size(45, 18);
            this.lbReplacedLicenseID.TabIndex = 161;
            this.lbReplacedLicenseID.Text = "[???]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DrivingLicenseManagement.Properties.Resources.user__3_;
            this.pictureBox2.Location = new System.Drawing.Point(935, 129);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 159;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.pictureBox4.Location = new System.Drawing.Point(937, 82);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 157;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.pictureBox5.Location = new System.Drawing.Point(937, 35);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 156;
            this.pictureBox5.TabStop = false;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label99.Location = new System.Drawing.Point(739, 128);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(96, 18);
            this.label99.TabIndex = 154;
            this.label99.Text = "Created By:";
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.l1.Location = new System.Drawing.Point(741, 81);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(123, 18);
            this.l1.TabIndex = 152;
            this.l1.Text = "Old License ID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(741, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 18);
            this.label10.TabIndex = 151;
            this.label10.Text = "Replaced License ID:";
            // 
            // lbApplcationFees
            // 
            this.lbApplcationFees.AutoSize = true;
            this.lbApplcationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplcationFees.Location = new System.Drawing.Point(257, 128);
            this.lbApplcationFees.Name = "lbApplcationFees";
            this.lbApplcationFees.Size = new System.Drawing.Size(45, 18);
            this.lbApplcationFees.TabIndex = 148;
            this.lbApplcationFees.Text = "[???]";
            // 
            // lbApplcationDate
            // 
            this.lbApplcationDate.AutoSize = true;
            this.lbApplcationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplcationDate.Location = new System.Drawing.Point(259, 81);
            this.lbApplcationDate.Name = "lbApplcationDate";
            this.lbApplcationDate.Size = new System.Drawing.Size(45, 18);
            this.lbApplcationDate.TabIndex = 146;
            this.lbApplcationDate.Text = "[???]";
            // 
            // lbRLAppplicationID
            // 
            this.lbRLAppplicationID.AutoSize = true;
            this.lbRLAppplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRLAppplicationID.Location = new System.Drawing.Point(259, 34);
            this.lbRLAppplicationID.Name = "lbRLAppplicationID";
            this.lbRLAppplicationID.Size = new System.Drawing.Size(45, 18);
            this.lbRLAppplicationID.TabIndex = 145;
            this.lbRLAppplicationID.Text = "[???]";
            // 
            // pictureBox18
            // 
            this.pictureBox18.Image = global::DrivingLicenseManagement.Properties.Resources.money;
            this.pictureBox18.Location = new System.Drawing.Point(181, 129);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(16, 16);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox18.TabIndex = 142;
            this.pictureBox18.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = global::DrivingLicenseManagement.Properties.Resources.calendar__1_;
            this.pictureBox16.Location = new System.Drawing.Point(183, 82);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(16, 16);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox16.TabIndex = 140;
            this.pictureBox16.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = global::DrivingLicenseManagement.Properties.Resources.id_card;
            this.pictureBox15.Location = new System.Drawing.Point(183, 35);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(16, 16);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 139;
            this.pictureBox15.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(13, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(137, 18);
            this.label17.TabIndex = 136;
            this.label17.Text = "Application Fees:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(15, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 18);
            this.label15.TabIndex = 134;
            this.label15.Text = "Application Date:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(15, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 18);
            this.label14.TabIndex = 133;
            this.label14.Text = "L.R.Application ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbCreatedBy);
            this.groupBox2.Controls.Add(this.lbOldLicenseID);
            this.groupBox2.Controls.Add(this.lbReplacedLicenseID);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.label99);
            this.groupBox2.Controls.Add(this.l1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbApplcationFees);
            this.groupBox2.Controls.Add(this.lbApplcationDate);
            this.groupBox2.Controls.Add(this.lbRLAppplicationID);
            this.groupBox2.Controls.Add(this.pictureBox18);
            this.groupBox2.Controls.Add(this.pictureBox16);
            this.groupBox2.Controls.Add(this.pictureBox15);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(11, 578);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1266, 180);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info For License Replacement";
            // 
            // frmReplacementForDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1288, 812);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxReplacementFor);
            this.Controls.Add(this.linkLabelNewShowLicenseInfo);
            this.Controls.Add(this.linkLabelShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.filterDriverLicenseInfo1);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplacementForDamagedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReplacementForDamagedLicense";
            this.Load += new System.EventHandler(this.frmReplacementForDamagedLicense_Load);
            this.groupBoxReplacementFor.ResumeLayout(false);
            this.groupBoxReplacementFor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabelNewShowLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseHistory;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnIssueReplacement;
        private FilterDriverLicenseInfo filterDriverLicenseInfo1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox groupBoxReplacementFor;
        private System.Windows.Forms.RadioButton radioButtonLostLicense;
        private System.Windows.Forms.RadioButton radioButtonDamagedLicense;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbOldLicenseID;
        private System.Windows.Forms.Label lbReplacedLicenseID;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbApplcationFees;
        private System.Windows.Forms.Label lbApplcationDate;
        private System.Windows.Forms.Label lbRLAppplicationID;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}