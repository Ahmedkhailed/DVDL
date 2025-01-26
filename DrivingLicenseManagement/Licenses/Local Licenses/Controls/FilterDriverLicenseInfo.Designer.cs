namespace DrivingLicenseManagement
{
    partial class FilterDriverLicenseInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFindBy = new System.Windows.Forms.TextBox();
            this.btnFindBy = new System.Windows.Forms.Label();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.driverLicenseInfo2 = new DrivingLicenseManagement.DriverLicenseInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbFindBy);
            this.groupBox1.Controls.Add(this.btnFindBy);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 82);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // tbFindBy
            // 
            this.tbFindBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbFindBy.Location = new System.Drawing.Point(151, 30);
            this.tbFindBy.Name = "tbFindBy";
            this.tbFindBy.Size = new System.Drawing.Size(278, 22);
            this.tbFindBy.TabIndex = 15;
            this.tbFindBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFindBy_KeyPress);
            this.tbFindBy.Validating += new System.ComponentModel.CancelEventHandler(this.tbFindBy_Validating);
            // 
            // btnFindBy
            // 
            this.btnFindBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFindBy.AutoSize = true;
            this.btnFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindBy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFindBy.Location = new System.Drawing.Point(24, 32);
            this.btnFindBy.Name = "btnFindBy";
            this.btnFindBy.Size = new System.Drawing.Size(77, 18);
            this.btnFindBy.TabIndex = 14;
            this.btnFindBy.Text = "LicenseID:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Animated = true;
            this.btnSearch.CheckedState.Parent = this.btnSearch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.CustomImages.Parent = this.btnSearch;
            this.btnSearch.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.HoverState.Parent = this.btnSearch;
            this.btnSearch.Image = global::DrivingLicenseManagement.Properties.Resources.licence;
            this.btnSearch.ImageSize = new System.Drawing.Size(27, 27);
            this.btnSearch.Location = new System.Drawing.Point(447, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.Size = new System.Drawing.Size(74, 42);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // driverLicenseInfo2
            // 
            this.driverLicenseInfo2.Location = new System.Drawing.Point(8, 102);
            this.driverLicenseInfo2.Name = "driverLicenseInfo2";
            this.driverLicenseInfo2.Size = new System.Drawing.Size(1281, 417);
            this.driverLicenseInfo2.TabIndex = 16;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FilterDriverLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.driverLicenseInfo2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FilterDriverLicenseInfo";
            this.Size = new System.Drawing.Size(1292, 526);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbFindBy;
        private System.Windows.Forms.Label btnFindBy;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private DriverLicenseInfo driverLicenseInfo2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
