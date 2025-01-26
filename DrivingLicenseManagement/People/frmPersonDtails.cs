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
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            show1.LoadPersonInfo(personID);
        }

        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            show1.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
