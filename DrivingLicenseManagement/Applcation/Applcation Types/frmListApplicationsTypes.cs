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
    public partial class frmListApplicationsTypes : Form
    {
        public frmListApplicationsTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            DataTable dt = clsApplicationTypes.GetAllApplicationTypes();
            dataGridView1.DataSource = dt;
            lbRecords.Text = dataGridView1.RowCount.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 400;

                dataGridView1.Columns[2].HeaderText = "Fees";
                dataGridView1.Columns[2].Width = 100;
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType updateApplicationType = new frmUpdateApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);
            updateApplicationType.ShowDialog();

            frmManageApplicationTypes_Load(null, null);
        }
    
    }
}
