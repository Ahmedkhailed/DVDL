using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement
{
    public partial class Filter : UserControl
    {
        public delegate void PersonIdSelectedEventHandler(int SelectedPersonId);
        public event PersonIdSelectedEventHandler OnPersonIdSelected;

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddUser.Visible = value;
            }
        }

        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }

        public Filter()
        {
            InitializeComponent();
        }

        private bool IsFilterSelected() => comboFilterBy.SelectedItem == null || string.IsNullOrEmpty(comboFilterBy.SelectedItem.ToString());

        private clsPerson FindPersonByNationalNumber() => clsPerson.Find(textBoxFindBy.Text.ToString());

        private clsPerson FindPersonByPersonID()
        {
            if (int.TryParse(textBoxFindBy.Text as string, out _PersonID))
            {
                return clsPerson.Find(_PersonID);
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Person ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void FindNow()
        {
            if (IsFilterSelected())
            {
                MessageBox.Show("Please select a filter option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsPerson People = comboFilterBy.SelectedItem as string switch 
            {
                 "National No" =>  FindPersonByNationalNumber(),
                 "PersonID" => FindPersonByPersonID(),
                 _ => null
            };

            if (People != null)
                OnPersonIdSelected?.Invoke(People.PersonID);
        }

        private void btnSearch_Click(object sender, EventArgs e) => FindNow();

        public void FindPersonByPersonID(int PersonID)
        {
            comboFilterBy.SelectedItem = "PersonID";
            textBoxFindBy.Text = PersonID.ToString();
            FindNow();
        }

        private void comboFilterBy_SelectedIndexChanged(object sender, EventArgs e) 
        {
            textBoxFindBy.Clear();
            textBoxFindBy.Focus();
        }

        private void Filter_Load(object sender, EventArgs e) 
        {
            comboFilterBy.SelectedIndex = 0;
            textBoxFindBy.Focus();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (frmAddEditPerson AddPerson = new frmAddEditPerson())
            {
                AddPerson.ShowDialog();
                _PersonID = AddPerson.PersonID;
                comboFilterBy.SelectedItem = "PersonID";
                textBoxFindBy.Text = _PersonID.ToString();
                FindNow();
            }
        }

        private void textBoxFindBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch.PerformClick();
        }

        private void textBoxFindBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnSearch.PerformClick();

            if (comboFilterBy.SelectedItem?.ToString() == "PersonID")
                e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back);
        }

        public void FilterFocus() => textBoxFindBy.Focus();
    }
}
