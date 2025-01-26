namespace DrivingLicenseManagement
{
    partial class frmListInternationalLicenseApplication
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
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.comboboxFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddInternationalLicense = new Guna.UI2.WinForms.Guna2Button();
            this.lbRecords = new System.Windows.Forms.Label();
            this.lavaf = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIsActive
            // 
            this.cbIsActive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbIsActive.DisplayMember = "0";
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "IsActive",
            "Inactive"});
            this.cbIsActive.Location = new System.Drawing.Point(368, 257);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(188, 24);
            this.cbIsActive.TabIndex = 22;
            this.cbIsActive.Tag = "";
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbFilterBy.Location = new System.Drawing.Point(368, 258);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(222, 22);
            this.tbFilterBy.TabIndex = 19;
            this.tbFilterBy.Visible = false;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            // 
            // comboboxFilterBy
            // 
            this.comboboxFilterBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboboxFilterBy.DisplayMember = "0";
            this.comboboxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxFilterBy.FormattingEnabled = true;
            this.comboboxFilterBy.Items.AddRange(new object[] {
            "none",
            "int.License ID",
            "Application ID",
            "Driver ID",
            "L.License ID",
            "Is Active"});
            this.comboboxFilterBy.Location = new System.Drawing.Point(110, 257);
            this.comboboxFilterBy.Name = "comboboxFilterBy";
            this.comboboxFilterBy.Size = new System.Drawing.Size(238, 24);
            this.comboboxFilterBy.TabIndex = 18;
            this.comboboxFilterBy.Tag = "";
            this.comboboxFilterBy.SelectedIndexChanged += new System.EventHandler(this.comboboxFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(16, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Filter By :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 311);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1419, 269);
            this.dataGridView1.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonDetails,
            this.ShowLicenseDetails,
            this.ShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(269, 82);
            // 
            // ShowPersonDetails
            // 
            this.ShowPersonDetails.Image = global::DrivingLicenseManagement.Properties.Resources.form;
            this.ShowPersonDetails.Name = "ShowPersonDetails";
            this.ShowPersonDetails.Size = new System.Drawing.Size(268, 26);
            this.ShowPersonDetails.Text = "Show Person Details";
            this.ShowPersonDetails.Click += new System.EventHandler(this.ShowPersonDetails_Click);
            // 
            // ShowLicenseDetails
            // 
            this.ShowLicenseDetails.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.ShowLicenseDetails.Name = "ShowLicenseDetails";
            this.ShowLicenseDetails.Size = new System.Drawing.Size(268, 26);
            this.ShowLicenseDetails.Text = "Show License Details ";
            this.ShowLicenseDetails.Click += new System.EventHandler(this.ShowLicenseDetails_Click);
            // 
            // ShowPersonLicenseHistory
            // 
            this.ShowPersonLicenseHistory.Image = global::DrivingLicenseManagement.Properties.Resources.order_history;
            this.ShowPersonLicenseHistory.Name = "ShowPersonLicenseHistory";
            this.ShowPersonLicenseHistory.Size = new System.Drawing.Size(268, 26);
            this.ShowPersonLicenseHistory.Text = "Show Person License History";
            this.ShowPersonLicenseHistory.Click += new System.EventHandler(this.ShowPersonLicenseHistory_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(469, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 36);
            this.label1.TabIndex = 15;
            this.label1.Text = "International License Application";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Animated = true;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::DrivingLicenseManagement.Properties.Resources.close__2_;
            this.btnClose.Location = new System.Drawing.Point(1335, 586);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(97, 32);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DrivingLicenseManagement.Properties.Resources.resume__6_;
            this.pictureBox1.Location = new System.Drawing.Point(581, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddInternationalLicense
            // 
            this.btnAddInternationalLicense.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddInternationalLicense.Animated = true;
            this.btnAddInternationalLicense.CheckedState.Parent = this.btnAddInternationalLicense;
            this.btnAddInternationalLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddInternationalLicense.CustomImages.Parent = this.btnAddInternationalLicense;
            this.btnAddInternationalLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnAddInternationalLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddInternationalLicense.ForeColor = System.Drawing.Color.Black;
            this.btnAddInternationalLicense.HoverState.Parent = this.btnAddInternationalLicense;
            this.btnAddInternationalLicense.Image = global::DrivingLicenseManagement.Properties.Resources.document;
            this.btnAddInternationalLicense.ImageSize = new System.Drawing.Size(32, 34);
            this.btnAddInternationalLicense.Location = new System.Drawing.Point(1358, 239);
            this.btnAddInternationalLicense.Name = "btnAddInternationalLicense";
            this.btnAddInternationalLicense.ShadowDecoration.Parent = this.btnAddInternationalLicense;
            this.btnAddInternationalLicense.Size = new System.Drawing.Size(74, 42);
            this.btnAddInternationalLicense.TabIndex = 20;
            this.btnAddInternationalLicense.Click += new System.EventHandler(this.btnAddInternationalLicense_Click);
            // 
            // lbRecords
            // 
            this.lbRecords.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbRecords.Location = new System.Drawing.Point(113, 600);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(16, 18);
            this.lbRecords.TabIndex = 24;
            this.lbRecords.Text = "0";
            // 
            // lavaf
            // 
            this.lavaf.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lavaf.AutoSize = true;
            this.lavaf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lavaf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lavaf.Location = new System.Drawing.Point(16, 600);
            this.lavaf.Name = "lavaf";
            this.lavaf.Size = new System.Drawing.Size(91, 18);
            this.lavaf.TabIndex = 23;
            this.lavaf.Text = "# Records:";
            // 
            // frmListInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1444, 641);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.lavaf);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.comboboxFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddInternationalLicense);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListInternationalLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListInternationalLicenseApplication";
            this.Load += new System.EventHandler(this.frmListInternationalLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIsActive;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.ComboBox comboboxFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnAddInternationalLicense;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonLicenseHistory;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label lavaf;
    }
}