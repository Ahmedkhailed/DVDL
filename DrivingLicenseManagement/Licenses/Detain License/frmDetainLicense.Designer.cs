namespace DrivingLicenseManagement
{
    partial class frmDetainLicense
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
            this.components = new System.ComponentModel.Container();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnDetain = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filterDriverLicenseInfo1 = new DrivingLicenseManagement.FilterDriverLicenseInfo();
            this.linkLabelNewShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.gbDetain = new System.Windows.Forms.GroupBox();
            this.tbFineFees = new System.Windows.Forms.TextBox();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbLicenseID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDetainDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDetainID = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDetain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(1099, 760);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(97, 32);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.Animated = true;
            this.btnDetain.CheckedState.Parent = this.btnDetain;
            this.btnDetain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetain.CustomImages.Parent = this.btnDetain;
            this.btnDetain.Enabled = false;
            this.btnDetain.FillColor = System.Drawing.Color.Transparent;
            this.btnDetain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetain.ForeColor = System.Drawing.Color.Black;
            this.btnDetain.HoverState.Parent = this.btnDetain;
            this.btnDetain.Image = global::DrivingLicenseManagement.Properties.Resources.world;
            this.btnDetain.Location = new System.Drawing.Point(1202, 760);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.ShadowDecoration.Parent = this.btnDetain;
            this.btnDetain.Size = new System.Drawing.Size(97, 32);
            this.btnDetain.TabIndex = 9;
            this.btnDetain.Text = "Detain";
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(543, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 36);
            this.label1.TabIndex = 10;
            this.label1.Text = "Detain License";
            // 
            // filterDriverLicenseInfo1
            // 
            this.filterDriverLicenseInfo1.FilterEnabled = true;
            this.filterDriverLicenseInfo1.Location = new System.Drawing.Point(9, 55);
            this.filterDriverLicenseInfo1.Name = "filterDriverLicenseInfo1";
            this.filterDriverLicenseInfo1.Size = new System.Drawing.Size(1292, 526);
            this.filterDriverLicenseInfo1.TabIndex = 11;
            this.filterDriverLicenseInfo1.LicenseIDSelected += new DrivingLicenseManagement.FilterDriverLicenseInfo.LicenseIDSelectedEventHandler(this.filterDriverLicenseInfo1_LicenseIDSelected);
            // 
            // linkLabelNewShowLicenseInfo
            // 
            this.linkLabelNewShowLicenseInfo.AutoSize = true;
            this.linkLabelNewShowLicenseInfo.Enabled = false;
            this.linkLabelNewShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelNewShowLicenseInfo.Location = new System.Drawing.Point(224, 767);
            this.linkLabelNewShowLicenseInfo.Name = "linkLabelNewShowLicenseInfo";
            this.linkLabelNewShowLicenseInfo.Size = new System.Drawing.Size(155, 18);
            this.linkLabelNewShowLicenseInfo.TabIndex = 169;
            this.linkLabelNewShowLicenseInfo.TabStop = true;
            this.linkLabelNewShowLicenseInfo.Text = "Show Licenses Info";
            this.linkLabelNewShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNewShowLicenseInfo_LinkClicked);
            // 
            // linkLabelShowLicenseHistory
            // 
            this.linkLabelShowLicenseHistory.AutoSize = true;
            this.linkLabelShowLicenseHistory.Enabled = false;
            this.linkLabelShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowLicenseHistory.Location = new System.Drawing.Point(12, 767);
            this.linkLabelShowLicenseHistory.Name = "linkLabelShowLicenseHistory";
            this.linkLabelShowLicenseHistory.Size = new System.Drawing.Size(181, 18);
            this.linkLabelShowLicenseHistory.TabIndex = 168;
            this.linkLabelShowLicenseHistory.TabStop = true;
            this.linkLabelShowLicenseHistory.Text = "Show Licenses History";
            this.linkLabelShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseHistory_LinkClicked);
            // 
            // gbDetain
            // 
            this.gbDetain.Controls.Add(this.tbFineFees);
            this.gbDetain.Controls.Add(this.lbCreatedBy);
            this.gbDetain.Controls.Add(this.pictureBox3);
            this.gbDetain.Controls.Add(this.label6);
            this.gbDetain.Controls.Add(this.lbLicenseID);
            this.gbDetain.Controls.Add(this.pictureBox4);
            this.gbDetain.Controls.Add(this.label8);
            this.gbDetain.Controls.Add(this.pictureBox2);
            this.gbDetain.Controls.Add(this.label4);
            this.gbDetain.Controls.Add(this.lbDetainDate);
            this.gbDetain.Controls.Add(this.pictureBox1);
            this.gbDetain.Controls.Add(this.label2);
            this.gbDetain.Controls.Add(this.lbDetainID);
            this.gbDetain.Controls.Add(this.pictureBox12);
            this.gbDetain.Controls.Add(this.label12);
            this.gbDetain.Location = new System.Drawing.Point(9, 587);
            this.gbDetain.Name = "gbDetain";
            this.gbDetain.Size = new System.Drawing.Size(1292, 164);
            this.gbDetain.TabIndex = 170;
            this.gbDetain.TabStop = false;
            this.gbDetain.Text = "Detain info";
            // 
            // tbFineFees
            // 
            this.tbFineFees.Location = new System.Drawing.Point(210, 106);
            this.tbFineFees.Name = "tbFineFees";
            this.tbFineFees.Size = new System.Drawing.Size(116, 22);
            this.tbFineFees.TabIndex = 114;
            this.tbFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.tbFineFees_Validating);
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(837, 70);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(45, 18);
            this.lbCreatedBy.TabIndex = 113;
            this.lbCreatedBy.Text = "[???]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DrivingLicenseManagement.Properties.Resources.editing;
            this.pictureBox3.Location = new System.Drawing.Point(794, 71);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 112;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(652, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 111;
            this.label6.Text = "Created By:";
            // 
            // lbLicenseID
            // 
            this.lbLicenseID.AutoSize = true;
            this.lbLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseID.Location = new System.Drawing.Point(837, 31);
            this.lbLicenseID.Name = "lbLicenseID";
            this.lbLicenseID.Size = new System.Drawing.Size(45, 18);
            this.lbLicenseID.TabIndex = 110;
            this.lbLicenseID.Text = "[???]";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.pictureBox4.Location = new System.Drawing.Point(794, 32);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 109;
            this.pictureBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(656, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 18);
            this.label8.TabIndex = 108;
            this.label8.Text = "License ID:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DrivingLicenseManagement.Properties.Resources.money;
            this.pictureBox2.Location = new System.Drawing.Point(163, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 106;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 105;
            this.label4.Text = "Fine Fees:";
            // 
            // lbDetainDate
            // 
            this.lbDetainDate.AutoSize = true;
            this.lbDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetainDate.Location = new System.Drawing.Point(207, 69);
            this.lbDetainDate.Name = "lbDetainDate";
            this.lbDetainDate.Size = new System.Drawing.Size(45, 18);
            this.lbDetainDate.TabIndex = 104;
            this.lbDetainDate.Text = "[???]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingLicenseManagement.Properties.Resources.calendar__1_;
            this.pictureBox1.Location = new System.Drawing.Point(163, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 102;
            this.label2.Text = "Detain Date:";
            // 
            // lbDetainID
            // 
            this.lbDetainID.AutoSize = true;
            this.lbDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetainID.Location = new System.Drawing.Point(207, 30);
            this.lbDetainID.Name = "lbDetainID";
            this.lbDetainID.Size = new System.Drawing.Size(45, 18);
            this.lbDetainID.TabIndex = 101;
            this.lbDetainID.Text = "[???]";
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = global::DrivingLicenseManagement.Properties.Resources.id_card;
            this.pictureBox12.Location = new System.Drawing.Point(163, 31);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(16, 16);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox12.TabIndex = 100;
            this.pictureBox12.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 18);
            this.label12.TabIndex = 99;
            this.label12.Text = "Detain ID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1311, 804);
            this.Controls.Add(this.gbDetain);
            this.Controls.Add(this.linkLabelNewShowLicenseInfo);
            this.Controls.Add(this.linkLabelShowLicenseHistory);
            this.Controls.Add(this.filterDriverLicenseInfo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDetainLicense";
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.gbDetain.ResumeLayout(false);
            this.gbDetain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnDetain;
        private System.Windows.Forms.Label label1;
        private FilterDriverLicenseInfo filterDriverLicenseInfo1;
        private System.Windows.Forms.LinkLabel linkLabelNewShowLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseHistory;
        private System.Windows.Forms.GroupBox gbDetain;
        private System.Windows.Forms.TextBox tbFineFees;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbLicenseID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDetainDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDetainID;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}