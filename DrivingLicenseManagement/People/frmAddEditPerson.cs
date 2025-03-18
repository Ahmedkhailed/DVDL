using ContactsBusinessLayer;
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
    public partial class frmAddEditPerson : Form
    {
        public int PersonID { get; set; }
        public clsPerson person { get; set; }

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
            addEdit1.PersonID = PersonID;
            lbTitle.Text = "Update Person";

            lbPersonID.Text = PersonID.ToString();
        }

        public frmAddEditPerson()
        {
            InitializeComponent();
            lbTitle.Text = "Save Person";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PersonID = addEdit1.SaveData();
            if (PersonID != -1)
            {
                lbPersonID.Text = PersonID.ToString();
                lbTitle.Text = "Update Person";
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
