using ContactsBusinessLayer;
using ContactsBusinessLayer.Detain;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.Users;
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
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _dtListDetain;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private string FilterColumnToString()
        {
            return comboboxFilterBy.SelectedItem.ToString() switch
            {
                "none" => "none",
                "Detain ID" => "DetainID",
                "National NO" => "NationalNO",
                "Released Application ID" => "ReleaseApplicationID",
                "Full Name" => "Full Name",
                "Is Released" => "IsReleased",
                _ => "none"
            };
        }

        private void _RefreshPeopleList()
        {
            string FilterColumn = FilterColumnToString();

            if (string.IsNullOrEmpty(tbFilterBy.Text.Trim()) && FilterColumn != "IsReleased")
            {
                _dtListDetain.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
            {
                _dtListDetain.DefaultView.RowFilter = string.Format($"{FilterColumn} = {tbFilterBy.Text.Trim()}");
            }
            else if (FilterColumn == "IsReleased")
            {
                _dtListDetain.DefaultView.RowFilter = cbActive.SelectedItem.ToString() switch
                {
                    "Yes" => string.Format($"{FilterColumn} = 1"),
                    "No" => string.Format($"{FilterColumn} = 0"),
                    _ => ""
                };
            }
            else
            {
                _dtListDetain.DefaultView.RowFilter = string.Format($"[{FilterColumn}] like '{tbFilterBy.Text.Trim()}%'");
            }
        }

        private void comboboxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxFilterBy.SelectedItem.ToString() == "none")
            {
                tbFilterBy.Visible = false;
                cbActive.Enabled = false;
            }
            else if (comboboxFilterBy.SelectedItem.ToString() == "Is Released")
            {
                tbFilterBy.Visible = false;
                cbActive.SelectedIndex = 0;
                cbActive.Visible = true;
                cbActive.Enabled = true;
            }
            else
            {
                cbActive.Visible = false;
                tbFilterBy.Visible = true;
                tbFilterBy.Text = "";
                tbFilterBy.Select();
            }
            _RefreshPeopleList();
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (comboboxFilterBy.SelectedItem.ToString() == "Detain ID" || comboboxFilterBy.SelectedItem.ToString() == "Released Application ID")
            {
                string newText = "";
                foreach (char c in tbFilterBy.Text)
                {
                    if (char.IsDigit(c))
                    {
                        newText += c;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Number");
                    }
                }
                tbFilterBy.Text = newText;
            }

            _RefreshPeopleList();
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense ReleaseDetainLicense = new frmReleaseDetainLicense();
            ReleaseDetainLicense.ShowDialog();
            this.frmListDetainedLicenses_Load(null, null);
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
            DetainLicense.ShowDialog();
            this.frmListDetainedLicenses_Load(null, null);
        }

        private void ReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense ReleaseDetainLicense = new frmReleaseDetainLicense((int)dataGridView1.CurrentRow.Cells["licenseID"].Value);
            ReleaseDetainLicense.ShowDialog();
            this.frmListDetainedLicenses_Load(null, null);
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e) => ReleaseDetainedLicense.Enabled = (!(bool)dataGridView1.CurrentRow.Cells["IsReleased"].Value);

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails PersonDetails = new frmPersonDetails(clsPerson.Find((string)dataGridView1.CurrentRow.Cells["NationalNo"].Value).PersonID);
            PersonDetails.ShowDialog();
            this.frmListDetainedLicenses_Load(null, null);
        }

        private void ShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmLicenseInfo LicenseInfo = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells["licenseID"].Value);
            LicenseInfo.ShowDialog();
            this.frmListDetainedLicenses_Load(null, null);
        }

        private void ShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmLicenseHistory LicenseHistory = new frmLicenseHistory(clsPerson.Find((string)dataGridView1.CurrentRow.Cells["NationalNo"].Value).PersonID);
            LicenseHistory.ShowDialog();
            this.frmListDetainedLicenses_Load(null, null);
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _dtListDetain = clsDetain.GetDetainedLicenses();
            dataGridView1.DataSource = _dtListDetain;
            comboboxFilterBy.SelectedIndex = 0;

            if (dataGridView1.RowCount > 0 )
            {
                dataGridView1.Columns[0].HeaderText = "D.ID";
                dataGridView1.Columns[0].Width = 75;

                dataGridView1.Columns[1].HeaderText = "L.ID";
                dataGridView1.Columns[1].Width = 75;

                dataGridView1.Columns[2].HeaderText = "D.Date";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Is Released";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "Fine Fees";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Release Date";
                dataGridView1.Columns[5].Width = 159;

                dataGridView1.Columns[6].HeaderText = "N.NO.";
                dataGridView1.Columns[6].Width = 100;

                dataGridView1.Columns[7].HeaderText = "Full Name";
                dataGridView1.Columns[7].Width = 200;

                dataGridView1.Columns[8].HeaderText = "Release App.ID";
                dataGridView1.Columns[8].Width = 80;
            }
        }
    
    }
}
