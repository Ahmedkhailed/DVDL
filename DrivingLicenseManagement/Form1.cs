using ContactsBusinessLayer.Users;
using DrivingLicenseManagement.Drivers;
using DrivingLicenseManagement.Golbal_Classes;
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
    public partial class Form1 : Form
    {
        LoginForm _loginForm;

        public Form1(LoginForm frm)
        {
            InitializeComponent();
            _loginForm = frm;
        }

        private void userControlCard1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmMangePeople  mangePeople = new frmMangePeople();
            mangePeople.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();

        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            contextMenuStripApplications.Show(btnApplications, new Point(0, btnApplications.Height));
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            userInfo.ShowDialog();
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            contextMenuStripAccountSetting.Show(btnAccountSettings, new Point(0,btnAccountSettings.Height));
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            changePassword.ShowDialog();
        }

        private void singToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _loginForm.Show();
            this.Close();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication localDrivingLicenseApplication = new frmAddUpdateLocalDrivingLicenseApplication();
            localDrivingLicenseApplication.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications LocalDrivingLicenseApplications = new frmLocalDrivingLicenseApplications();
            LocalDrivingLicenseApplications.Show();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationsTypes applicationTypes = new frmListApplicationsTypes();
            applicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestType ListTestType = new frmListTestType();
            ListTestType.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication internationalLicenseApplication = new frmNewInternationalLicenseApplication();
            internationalLicenseApplication.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenseApplication ListInternationalLicenseApplication = new frmListInternationalLicenseApplication();
            ListInternationalLicenseApplication.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense RenewLocalDrivingLicense = new frmRenewLocalDrivingLicense();
            RenewLocalDrivingLicense.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForDamagedLicense ReplacementForDamgedLicense = new frmReplacementForDamagedLicense();
            ReplacementForDamgedLicense.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
            DetainLicense.ShowDialog();
        }
        
        private void btnDrivers_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense releaseDetainLicense = new frmReleaseDetainLicense();
            releaseDetainLicense.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense releaseDetainLicense = new frmReleaseDetainLicense();
            releaseDetainLicense.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications LocalDrivingLicenseApplications = new frmLocalDrivingLicenseApplications();
            LocalDrivingLicenseApplications.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses ListDetainedLicenses = new frmListDetainedLicenses();
            ListDetainedLicenses.ShowDialog();
        }

        private void contextMenuStripApplications_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
