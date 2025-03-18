using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ContactsBusinessLayer;

namespace DrivingLicenseManagement
{
    public partial class frmMangePeople : Form
    {
        private DataTable GetPeopleData()
        {
            return clsPerson.GetAllPeople().DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "Gendor", "DateOfBirth", "CountryName", "Phone", "Email");
        }

        private DataTable _dtPeople;

        public frmMangePeople()
        {
            InitializeComponent();
        }

        private string FilterColumnToString()
        {
            return comboboxFilterBy.SelectedItem.ToString() switch
            {
                "none" => "none",
                "PersonID" => "PersonID",
                "National No" => "NationalNo",
                "First Name" => "FirstName",
                "Secound Name" => "SecondName",
                "Thired Name" => "ThirdName",
                "Last Name" => "LastName",
                "Nationality" => "Nationality",
                "Gendor" => "Gendor",
                "Phone" => "Phone",
                "Email" => "Email",
                _ => throw new ArgumentException("none")
            };
        }

        private void _RefreshPeopleList()
        {
            string FilterColumn = FilterColumnToString();

            if (FilterColumn == "none" || tbFilterBy.Text.Trim() == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lbRecords.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, tbFilterBy.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, tbFilterBy.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void comboboxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxFilterBy.Text == "none")
            {
                tbFilterBy.Visible = false;
            }
            else
            {
                tbFilterBy.Visible = true;
                tbFilterBy.Select();
            }
            tbFilterBy.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnAddPeople_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmEditPerson = new frmAddEditPerson();
            frmEditPerson.ShowDialog();
            frmMangePeople_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson editPerson = new frmAddEditPerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            editPerson.ShowDialog();
            frmMangePeople_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPerson = new frmPersonDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmPerson.ShowDialog();
            frmMangePeople_Load(null, null);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmEditPerson = new frmAddEditPerson();
            frmEditPerson.ShowDialog();
            frmMangePeople_Load(null, null);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person" + (int)dataGridView1.CurrentRow.Cells[0].Value, "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.DeletePersonByID((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted successfully", "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMangePeople_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked it.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Not Rady", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Not Rady", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmMangePeople_Load(object sender, EventArgs e)
        {
            _dtPeople = GetPeopleData();
            dataGridView1.DataSource = _dtPeople;
            comboboxFilterBy.SelectedIndex = 0;
            lbRecords.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "National No.";
                dataGridView1.Columns[1].Width = 120;


                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 140;


                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 120;

                dataGridView1.Columns[6].HeaderText = "Gender";
                dataGridView1.Columns[6].Width = 120;

                dataGridView1.Columns[7].HeaderText = "Date Of Birth";
                dataGridView1.Columns[7].Width = 140;

                dataGridView1.Columns[8].HeaderText = "Nationality";
                dataGridView1.Columns[8].Width = 120;


                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 120;


                dataGridView1.Columns[10].HeaderText = "Email";
                dataGridView1.Columns[10].Width = 170;
            }
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxFilterBy.SelectedItem?.ToString() == "PersonID")
                e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back);
        }

    }
}
