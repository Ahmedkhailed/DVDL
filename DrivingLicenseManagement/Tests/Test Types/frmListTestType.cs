using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.MangeApplicationTypes;
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
    public partial class frmListTestType : Form
    {
        public frmListTestType()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmListTestType_Load(object sender, EventArgs e)
        {
            DataTable dt = clsTestType.GetAllTestTypes();
            dataGridView1.DataSource = dt;
            lbRecords.Text = dt.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Description";
                dataGridView1.Columns[2].Width = 400;

                dataGridView1.Columns[3].HeaderText = "Fees";
                dataGridView1.Columns[3].Width = 100;
            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType testType = new frmUpdateTestType((clsTestType.enTestType)dataGridView1.CurrentRow.Cells[0].Value);
            testType.ShowDialog();
            frmListTestType_Load(null, null);
        }
    }
}
