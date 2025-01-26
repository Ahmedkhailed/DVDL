using ContactsBusinessLayer;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.InternationalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement.Drivers
{
    public partial class frmListDrivers : Form
    {
        private DataTable _dtDrivers = clsDrivers.GetAllDrivers();

        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dtDrivers;
            comboboxFilterBy.SelectedIndex = 0;
            lbRecords.Text = dataGridView1.RowCount.ToString();

            if (dataGridView1.RowCount > 0 )
            {
                dataGridView1.Columns[0].HeaderText = "Driver ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "National No";
                dataGridView1.Columns[2].Width = 110;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 220;

                dataGridView1.Columns[4].HeaderText = "Date";
                dataGridView1.Columns[4].Width = 110;

                dataGridView1.Columns[5].HeaderText = "Active Licenses";
                dataGridView1.Columns[5].Width = 110;

            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private string FilterColumnToString()
        {
            return comboboxFilterBy.SelectedItem.ToString() switch
            {
                "none" => "none",
                "Driver ID" => "DriverID",
                "Person ID" => "PersonID",
                "National NO." => "NationalNO",
                "Full Name" => "FullName",
                _ => "none"
            };
        }

        private void _RefreshDriverList()
        {
            string FilterColumn = FilterColumnToString();

            if (FilterColumn == "none" || tbFilterBy.Text.Trim() == "")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                lbRecords.Text = dataGridView1.RowCount.ToString();
                return;
            }

            if (FilterColumn == "DriverID" || FilterColumn == "PersonID")
                _dtDrivers.DefaultView.RowFilter = string.Format($"{FilterColumn} = '{tbFilterBy.Text.Trim()}'");
            else
                _dtDrivers.DefaultView.RowFilter = string.Format($"{FilterColumn} like '{tbFilterBy.Text.Trim()}%'");

            lbRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void comboBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterBy.Text = "";
            if (comboboxFilterBy.SelectedItem.ToString() == "none")
            {
                tbFilterBy.Visible = false;
            }
            else
            {
                tbFilterBy.Visible = true;
                tbFilterBy.Focus();
            }
            _RefreshDriverList();
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (comboboxFilterBy.SelectedItem.ToString() == "Driver ID" || comboboxFilterBy.SelectedItem.ToString() == "Person ID")
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

            _RefreshDriverList();
        }

        private void ShowPersonDetails_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dataGridView1.CurrentRow.Cells["PersonID"].Value);
            frm.ShowDialog();
        }

        private void ShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((int)dataGridView1.CurrentRow.Cells["PersonID"].Value);
            frm.ShowDialog();
        }
    }
}
