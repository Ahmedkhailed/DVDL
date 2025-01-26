using ContactsBusinessLayer;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.InternationalLicenses;
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
    public partial class frmListInternationalLicenseApplication : Form
    {
        private clsUsers User;
        private DataTable _dtListInternationalLicense;

        public frmListInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private string FilterColumnToString()
        {
            return comboboxFilterBy.SelectedItem.ToString() switch
            {
                "none" => "none",
                "int.License ID" => "InternationalLicenseID",
                "Application ID" => "ApplicationID",
                "Driver ID" => "DriverID",
                "L.License ID" => "IssuedUsingLocalLicenseID",
                "Is Active" => "IsActive",
                _ => "none"
            };
        }

        private void _RefreshList()
        {
            string FilterColumn = FilterColumnToString();

            if (FilterColumn == "none" || tbFilterBy.Text.Trim() == "")
            {
                return;
            }
            else if (FilterColumn == "IsActive")
            {
                _dtListInternationalLicense.DefaultView.RowFilter = cbIsActive.SelectedItem.ToString() switch
                {
                    "IsActive" => string.Format($"{FilterColumn} = 1"),
                    "Inactive" => string.Format($"{FilterColumn} = 0"),
                    _ => ""
                };
            }
            else
            {
                _dtListInternationalLicense.DefaultView.RowFilter = string.Format($"{FilterColumn} = {tbFilterBy.Text.Trim()}");
            }
            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void ShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int PersonID = clsDrivers.FindByDriverID((int)dataGridView1.CurrentRow.Cells[2].Value).PersonID;
            frmLicenseHistory LicenseHistory = new frmLicenseHistory(PersonID);
            LicenseHistory.ShowDialog();
        }

        private void ShowPersonDetails_Click(object sender, EventArgs e)
        {
            int PersonID = clsDrivers.FindByDriverID((int)dataGridView1.CurrentRow.Cells[2].Value).PersonID;
            frmPersonDetails personDetails = new frmPersonDetails(PersonID);
            personDetails.ShowDialog();
        }

        private void ShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmInternationalDriverInfo InternationalDriverInfo = new frmInternationalDriverInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            InternationalDriverInfo.ShowDialog();
        }

        private void comboboxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxFilterBy.SelectedItem.ToString() == "none")
            {
                tbFilterBy.Visible = false;
                cbIsActive.Visible = false;
            }
            else if (comboboxFilterBy.SelectedItem.ToString() == "Is Active")
            {
                tbFilterBy.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                tbFilterBy.Visible = true;
                cbIsActive.Visible = false;
                tbFilterBy.Text = "";
                tbFilterBy.Select();
            }
            _RefreshList();
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (tbFilterBy.Text.Trim() != "")
            {
                string newText = "";
                foreach (char c in tbFilterBy.Text)
                {
                    if (char.IsDigit(c))
                    {
                        newText += c;
                    }
                }
                tbFilterBy.Text = newText;
            }

            _RefreshList();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e) => _RefreshList();

        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frmNewInternationalLicenseApplication = new frmNewInternationalLicenseApplication();
            frmNewInternationalLicenseApplication.ShowDialog();
        }

        private void frmListInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            comboboxFilterBy.SelectedIndex = 0; 
            _dtListInternationalLicense = clsInternationalLicenses.GetAllInternationalLicenses();

            dataGridView1.DataSource = _dtListInternationalLicense;

            if (dataGridView1.Rows.Count > 0 )
            {
                dataGridView1.Columns[0].HeaderText = "int.License ID";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "Application ID";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "Driver ID";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "L.License ID";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "Issue Date";
                dataGridView1.Columns[4].Width = 175;

                dataGridView1.Columns[5].HeaderText = "Expiration Date";
                dataGridView1.Columns[5].Width = 175;

                dataGridView1.Columns[6].HeaderText = "Is Active";
                dataGridView1.Columns[6].Width = 175;
            }
            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

    }
}
