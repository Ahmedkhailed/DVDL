using ContactsBusinessLayer;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.Users;
using DrivingLicenseManagement.Golbal_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DrivingLicenseManagement
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        private static DataTable _dtAllLocalDrivingLicense;

        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private string FilterColumnToString()
        {
            return comboBoxFilterBy.SelectedItem.ToString() switch
            {
                "none" => "none",
                "L.D.LAppID" => "LocalDrivingLicenseApplicationID",
                "National No" => "NationalNo",
                "Full Name" => "FullName",
                "Status" => "Status",
                _ => "none"
            };
        }

        private void _RefreshList()
        {
            string FilterColumn = FilterColumnToString();

            if (FilterColumn == "none" || (tbFilterBy.Text.Trim() == "" && cbStatus.SelectedItem.ToString() == "All"))
            {
                _dtAllLocalDrivingLicense.DefaultView.RowFilter = "";
            }
            else if (FilterColumn == "Status")
            {
                _dtAllLocalDrivingLicense.DefaultView.RowFilter = cbStatus.SelectedItem.ToString() switch
                {
                    "New" => string.Format($"{FilterColumn} = 'New'"),
                    "Completed" => string.Format($"{FilterColumn} = 'Completed'"),
                    "Cancelled" => string.Format($"{FilterColumn} = 'Cancelled'"),
                    _ => ""
                };
            }
            else if (comboBoxFilterBy.SelectedItem.ToString() == "L.D.LAppID")
                _dtAllLocalDrivingLicense.DefaultView.RowFilter = string.Format($"{FilterColumn} = {tbFilterBy.Text.Trim()}");
            else
                _dtAllLocalDrivingLicense.DefaultView.RowFilter = $"{FilterColumn} like '{tbFilterBy.Text.Trim()}%'";

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtAllLocalDrivingLicense = clsLocalDrivingLicenseApplications.GetAllDrivingLicenseApplication();
            dataGridView1.DataSource = _dtAllLocalDrivingLicense;
            comboBoxFilterBy.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            lbRecords.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "L.D.LAppID";
                dataGridView1.Columns[0].Width = 105;

                dataGridView1.Columns[1].HeaderText = "Driving Class";
                dataGridView1.Columns[1].Width = 200;


                dataGridView1.Columns[2].HeaderText = "National No.";
                dataGridView1.Columns[2].Width = 110;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 229;


                dataGridView1.Columns[4].HeaderText = "Application Date";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "Passed Tests";
                dataGridView1.Columns[5].Width = 110;

                dataGridView1.Columns[6].HeaderText = "Status";
                dataGridView1.Columns[6].Width = 120;
            }

        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frmUpdateLocalDrivingLicenseApplication = new frmAddUpdateLocalDrivingLicenseApplication();
            frmUpdateLocalDrivingLicenseApplication.ShowDialog();
            this.frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void ShowApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo drivingLicenseApplicationInfo = new frmLocalDrivingLicenseApplicationInfo((int)dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            drivingLicenseApplicationInfo.ShowDialog();
            this.frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisionTestAppointments visionTestAppointments = new frmVisionTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, ContactsBusinessLayer.clsManageTestApplication.clsTestType.enTestType.VisionTest);
            visionTestAppointments.ShowDialog();
            this.frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void _CheckInt()
        {
            if (comboBoxFilterBy.SelectedItem.ToString() == "L.D.LAppID")
            {
                string newText = "";
                foreach (char c in tbFilterBy.Text)
                {
                    if (char.IsDigit(c))
                        newText += c;
                }
                tbFilterBy.Text = newText;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFilterBy.SelectedItem.ToString() == "none")
            {
                tbFilterBy.Visible = false;
                cbStatus.Visible = false;
            }
            else if (comboBoxFilterBy.SelectedItem.ToString() == "Status")
            {
                tbFilterBy.Visible = false;
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = 0;
            }
            else
            {
                tbFilterBy.Visible = true;
                cbStatus.Visible = false;
                tbFilterBy.Text = "";
                tbFilterBy.Select();
            }
            _RefreshList();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this Application?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID((int)dataGridView1.CurrentRow.Cells[0].Value).Delete())
                {
                    MessageBox.Show("Application Delete successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not Deleted Application, other data depends on it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to Cancel this Application?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID((int)dataGridView1.CurrentRow.Cells[0].Value).Cancel())
                {
                    MessageBox.Show("Application Cancelled successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not Cancel Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            _CheckInt();
            _RefreshList();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e) => _RefreshList();

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int TotalPassedTests = (int)dataGridView1.CurrentRow.Cells["PassedTestCount"].Value;
            string Status = (string)dataGridView1.CurrentRow.Cells["Status"].Value;

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3 && Status == "New");
            showLicenseToolStripMenuItem.Enabled = (TotalPassedTests == 3 && Status == "Completed");

            editToolStripMenuItem.Enabled = (Status == "New");
            deleteApplicationToolStripMenuItem.Enabled = (Status == "New");
            cancelApplicationToolStripMenuItem.Enabled = (Status == "New");

            sechduleTestsToolStripMenuItem.Enabled = (TotalPassedTests != 3 && Status == "New");
            if (sechduleTestsToolStripMenuItem.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = (TotalPassedTests == 0);
                scheduleWrittenTestToolStripMenuItem.Enabled = (TotalPassedTests == 1);
                scheduleStreetTestToolStripMenuItem.Enabled = (TotalPassedTests == 2);
            }
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisionTestAppointments visionTestAppointments = new frmVisionTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, ContactsBusinessLayer.clsManageTestApplication.clsTestType.enTestType.StreetTest);
            visionTestAppointments.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisionTestAppointments visionTestAppointments = new frmVisionTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, ContactsBusinessLayer.clsManageTestApplication.clsTestType.enTestType.WrittenTest);
            visionTestAppointments.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseForTheFirstTime IssueDriverLicenseForTheFirstTime = new frmIssueDriverLicenseForTheFirstTime((int)dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            IssueDriverLicenseForTheFirstTime.ShowDialog();
            this.frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication AddUpdateLocalDrivingLicenseApplication = new frmAddUpdateLocalDrivingLicenseApplication((int)dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            AddUpdateLocalDrivingLicenseApplication.ShowDialog();
            this.frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID((int)dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value).GetActiveLicenseID();
            frmLicenseInfo licenseInfo = new frmLicenseInfo(LicenseID);
            licenseInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPerson.Find((string)dataGridView1.CurrentRow.Cells["NationalNo"].Value).PersonID;
            frmLicenseHistory licenseHistory = new frmLicenseHistory(PersonID);
            licenseHistory.ShowDialog();
        }

    }
}
