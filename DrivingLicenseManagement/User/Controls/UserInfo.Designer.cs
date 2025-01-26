namespace DrivingLicenseManagement
{
    partial class UserInfo
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
            this.show2 = new DrivingLicenseManagement.ctrlPersonCard();
            this.loginInformation2 = new DrivingLicenseManagement.LoginInformation();
            this.SuspendLayout();
            // 
            // show2
            // 
            this.show2.Dock = System.Windows.Forms.DockStyle.Top;
            this.show2.Location = new System.Drawing.Point(0, 0);
            this.show2.Name = "show2";
            this.show2.Size = new System.Drawing.Size(758, 350);
            this.show2.TabIndex = 0;
            // 
            // loginInformation2
            // 
            this.loginInformation2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginInformation2.Location = new System.Drawing.Point(0, 361);
            this.loginInformation2.Name = "loginInformation2";
            this.loginInformation2.Size = new System.Drawing.Size(758, 125);
            this.loginInformation2.TabIndex = 1;
            // 
            // UserInfo
            // 
            this.Controls.Add(this.loginInformation2);
            this.Controls.Add(this.show2);
            this.Name = "UserInfo";
            this.Size = new System.Drawing.Size(758, 486);
            this.ResumeLayout(false);

        }

        #endregion
        private ctrlPersonCard show2;
        private LoginInformation loginInformation2;
    }
}
