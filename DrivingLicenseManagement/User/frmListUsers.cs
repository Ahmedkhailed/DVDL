using ContactsBusinessLayer;
using ContactsBusinessLayer.Users;
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
    public partial class frmListUsers : Form
    {
        private static DataTable _dtUser = clsUsers.GetAllUsers();
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dtUser;
            comboboxFilterBy.SelectedIndex = 0;
            lbRecords.Text = dataGridView1.RowCount.ToString();

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 120;


                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "UserName";
                dataGridView1.Columns[3].Width = 140;


                dataGridView1.Columns[4].HeaderText = "Is Active";
                dataGridView1.Columns[4].Width = 120;
            }
        }

        private string FilterColumnToString()
        {
            return comboboxFilterBy.SelectedItem.ToString() switch
            {
                "none" => "none",
                "User ID" => "UserID",
                "User Name" => "UserName",
                "PersonID" => "PersonID",
                "Full Name" => "FullName",
                "Is Active" => "IsActive",
                _ => "none"
            };
        }

        private void _RefreshPeopleList()
        {
            string FilterColumn = FilterColumnToString();

            if (FilterColumn == "none" || tbFilterBy.Text.Trim() == "")
            {
                _dtUser.DefaultView.RowFilter = "";
                lbRecords.Text = dataGridView1.RowCount.ToString();
                return;
            }

            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
                _dtUser.DefaultView.RowFilter = string.Format($"{FilterColumn} = {tbFilterBy.Text.Trim()}");
            else if (FilterColumn == "IsActive")
            {
                _dtUser.DefaultView.RowFilter = cbActive.SelectedItem.ToString() switch
                {
                    "Yes" => string.Format($"{FilterColumn} = 1"),
                    "No" => string.Format($"{FilterColumn} = 0"),
                    _ => ""
                };
            }
            else
                _dtUser.DefaultView.RowFilter = string.Format($"{FilterColumn} like '{tbFilterBy.Text.Trim()}%'");

            lbRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void comboboxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxFilterBy.SelectedItem.ToString() == "Is Active")
            {
                tbFilterBy.Visible = false;
                cbActive.SelectedIndex = 0;
                cbActive.Visible = true;
                cbActive.Focus();
            }
            else
            {
                cbActive.Visible = false;
                tbFilterBy.Visible = (comboboxFilterBy.Text != "none");
                tbFilterBy.Text = "";
                tbFilterBy.Select();
                tbFilterBy.Focus();
            }
            _RefreshPeopleList();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (comboboxFilterBy.SelectedItem.ToString() == "PersonID" || comboboxFilterBy.SelectedItem.ToString() == "User ID")
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

            _RefreshPeopleList();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            FormAddNewUser AddNewUser = new FormAddNewUser();
            AddNewUser.ShowDialog();
            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser AddNewUser = new FormAddNewUser();
            AddNewUser.ShowDialog();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUsers.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User has been deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshPeopleList();
            }
            else
                MessageBox.Show("User is not deleted due to data connected to it.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Not Rady", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Not Rady", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e) => _RefreshPeopleList();

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser EditNewUser = new FormAddNewUser((int)dataGridView1.CurrentRow.Cells["UserID"].Value);
            EditNewUser.ShowDialog();
            _RefreshPeopleList();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            changePassword.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userInfo = new frmUserInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            userInfo.ShowDialog();
        }
    
    }
}
