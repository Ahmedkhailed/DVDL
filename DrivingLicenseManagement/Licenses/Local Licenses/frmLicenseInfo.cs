using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement
{
    public partial class frmLicenseInfo : Form
    {
        private int _licenseID = -1;
        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _licenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmLicenseInfo_Load(object sender, EventArgs e) => driverLicenseInfo1.LoadData(_licenseID);

    }
}
