using ContactsBusinessLayer.clsManageTestApplication;
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
    public partial class frmUpdateTestType : Form
    {
        private clsTestType _TestType;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmUpdateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not vailed!, put the mouse over the red icon(s) to see the error.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            _TestType.Title = tbTitle.Text.Trim();
            _TestType.Description = tbDescription.Text.Trim();
            _TestType.Fees = Convert.ToDecimal(tbFees.Text.Trim());

            if (_TestType.Save())
                MessageBox.Show("Data Saved Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error : Data is not save successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);
            if (_TestType != null)
            {
                lbID.Text = _TestType.ID.ToString();
                tbFees.Text = _TestType.Fees.ToString();
                tbDescription.Text = _TestType.Description;
                tbTitle.Text = _TestType.Title;
            }
            else
            {
                MessageBox.Show("Could not find test type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text))
                errorProvider1.SetError(tbTitle, "Title cannot be empty!");
            else
                errorProvider1.SetError(tbTitle, null);
        }

        private void tbDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDescription.Text))
                errorProvider1.SetError(tbDescription, "Description cannot be empty!");
            else
                errorProvider1.SetError(tbDescription, null);
        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text))
                errorProvider1.SetError(tbFees, "Fees cannot be empty!");
            else if (!clsValidation.IsNumber(tbFees.Text.ToString()))
                errorProvider1.SetError(tbFees, "Invalid Number.");
            else
                errorProvider1.SetError(tbFees, null);
        }

        private void tbFees_TextChanged(object sender, EventArgs e)
        {
            string newText = "";
            foreach (char c in tbFees.Text)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    newText += c;
                }
            }
            tbFees.Text = newText;
        }

    }
}
