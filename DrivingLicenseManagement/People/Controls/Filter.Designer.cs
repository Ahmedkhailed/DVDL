namespace DrivingLicenseManagement
{
    partial class Filter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFindBy = new System.Windows.Forms.TextBox();
            this.comboFilterBy = new System.Windows.Forms.ComboBox();
            this.btnFindBy = new System.Windows.Forms.Label();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFindBy);
            this.groupBox1.Controls.Add(this.comboFilterBy);
            this.groupBox1.Controls.Add(this.btnFindBy);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnAddUser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // textBoxFindBy
            // 
            this.textBoxFindBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFindBy.Location = new System.Drawing.Point(286, 32);
            this.textBoxFindBy.Name = "textBoxFindBy";
            this.textBoxFindBy.Size = new System.Drawing.Size(184, 22);
            this.textBoxFindBy.TabIndex = 12;
            this.textBoxFindBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindBy_KeyDown);
            this.textBoxFindBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFindBy_KeyPress);
            // 
            // comboFilterBy
            // 
            this.comboFilterBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboFilterBy.DisplayMember = "0";
            this.comboFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilterBy.FormattingEnabled = true;
            this.comboFilterBy.Items.AddRange(new object[] {
            "National No",
            "PersonID"});
            this.comboFilterBy.Location = new System.Drawing.Point(86, 31);
            this.comboFilterBy.Name = "comboFilterBy";
            this.comboFilterBy.Size = new System.Drawing.Size(194, 24);
            this.comboFilterBy.TabIndex = 11;
            this.comboFilterBy.Tag = "";
            this.comboFilterBy.SelectedIndexChanged += new System.EventHandler(this.comboFilterBy_SelectedIndexChanged);
            // 
            // btnFindBy
            // 
            this.btnFindBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFindBy.AutoSize = true;
            this.btnFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindBy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFindBy.Location = new System.Drawing.Point(15, 34);
            this.btnFindBy.Name = "btnFindBy";
            this.btnFindBy.Size = new System.Drawing.Size(65, 18);
            this.btnFindBy.TabIndex = 10;
            this.btnFindBy.Text = "Find By :";
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
            this.btnSearch.Image = global::DrivingLicenseManagement.Properties.Resources.user_avatar;
            this.btnSearch.ImageSize = new System.Drawing.Size(27, 27);
            this.btnSearch.Location = new System.Drawing.Point(476, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.Size = new System.Drawing.Size(74, 42);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddUser.Animated = true;
            this.btnAddUser.CheckedState.Parent = this.btnAddUser;
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.CustomImages.Parent = this.btnAddUser;
            this.btnAddUser.FillColor = System.Drawing.Color.Transparent;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddUser.ForeColor = System.Drawing.Color.Black;
            this.btnAddUser.HoverState.Parent = this.btnAddUser;
            this.btnAddUser.Image = global::DrivingLicenseManagement.Properties.Resources.new_user;
            this.btnAddUser.ImageSize = new System.Drawing.Size(27, 27);
            this.btnAddUser.Location = new System.Drawing.Point(556, 22);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.ShadowDecoration.Parent = this.btnAddUser;
            this.btnAddUser.Size = new System.Drawing.Size(74, 42);
            this.btnAddUser.TabIndex = 8;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Filter";
            this.Size = new System.Drawing.Size(756, 88);
            this.Load += new System.EventHandler(this.Filter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.ComboBox comboFilterBy;
        private System.Windows.Forms.Label btnFindBy;
        private System.Windows.Forms.TextBox textBoxFindBy;
    }
}
