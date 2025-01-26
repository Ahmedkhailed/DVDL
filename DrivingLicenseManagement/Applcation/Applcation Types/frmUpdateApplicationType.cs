using ContactsBusinessLayer.MangeApplicationTypes;
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
using static System.Net.Mime.MediaTypeNames;

namespace DrivingLicenseManagement
{
    public partial class frmUpdateApplicationType : Form
    {
        private int _ApplicationID;
        private clsApplicationTypes _ApplicationTypes;

        public frmUpdateApplicationType(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                MessageBox.Show("Some Files are not vailed!, but the mouse over the red icon(s).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationTypes.Title = tbTitle.Text.Trim();
            _ApplicationTypes.Fees = Convert.ToDecimal(tbFees.Text);

            if (_ApplicationTypes.Save())
                MessageBox.Show("Data Saved Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error : Data Is not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationTypes = clsApplicationTypes.Find(_ApplicationID);
            if (_ApplicationTypes != null)
            {
                lbID.Text = _ApplicationTypes.ID.ToString();
                tbFees.Text = _ApplicationTypes.Fees.ToString();
                tbTitle.Text = _ApplicationTypes.Title.ToString();
            }
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

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text))
                errorProvider1.SetError(tbTitle, "Title cannot be empty!");
            else
                errorProvider1.SetError(tbTitle, null);
        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text))
                errorProvider1.SetError(tbFees, "Fees cannot be empty!");
            else if (!clsValidation.IsNumber(tbFees.Text))
                errorProvider1.SetError(tbFees, "Invalid Number");
            else
                errorProvider1.SetError(tbFees, null);
        }

    }
}
