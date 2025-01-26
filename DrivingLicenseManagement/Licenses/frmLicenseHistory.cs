using ContactsBusinessLayer;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.Local_Driving_License_Applications;
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
    public partial class frmLicenseHistory : Form
    {
        private int _PersonID = -1;

        public frmLicenseHistory()
        {
            InitializeComponent();
        }

        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                findPeople1.LoadPersonInfo(_PersonID);
                findPeople1.FilterEnabled = false;
            }
            else
            {
                findPeople1.FilterEnabled = true;
                findPeople1.FilterFocus();
            }
        }

        private void findPeople1_BackData(int PersonId)
        {
            if (_PersonID != -1)
                driverLicenses1.FileDataByPersonID(PersonId);
            else
                driverLicenses1.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

    }
}
