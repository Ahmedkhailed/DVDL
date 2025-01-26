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
    public partial class frmInternationalDriverInfo : Form
    {
        private int _InternationalID = -1;
        public frmInternationalDriverInfo(int InternationalID)
        {
            InitializeComponent();
            _InternationalID = InternationalID;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmInternationalDriverInfo_Load(object sender, EventArgs e) => driverLicenseInternationalInfo1.FillData(_InternationalID);
    }
}
