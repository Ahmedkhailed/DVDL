namespace DrivingLicenseManagement
{
    partial class ctrlPersonCardWithFilter
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
            this.filter1 = new DrivingLicenseManagement.Filter();
            this.ctrlPersonCard1 = new DrivingLicenseManagement.ctrlPersonCard();
            this.SuspendLayout();
            // 
            // filter1
            // 
            this.filter1.Location = new System.Drawing.Point(3, 3);
            this.filter1.Name = "filter1";
            this.filter1.Size = new System.Drawing.Size(756, 96);
            this.filter1.TabIndex = 0;
            this.filter1.OnPersonIdSelected += new DrivingLicenseManagement.Filter.PersonIdSelectedEventHandler(this.filter2_OnPersonIdSelected);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 105);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(756, 350);
            this.ctrlPersonCard1.TabIndex = 1;
            // 
            // FindPeople
            // 
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.filter1);
            this.Name = "FindPeople";
            this.Size = new System.Drawing.Size(765, 455);
            this.ResumeLayout(false);

        }

        #endregion

        private Filter filter1;
        private ctrlPersonCard ctrlPersonCard1;
    }
}
