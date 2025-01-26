using ContactsBusinessLayer;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.InternationalLicenses;
using ContactsBusinessLayer.Local_Driving_License_Applications;
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
    public partial class DriverLicenses : UserControl
    {
        private int _DriverID = -1;
        private clsDrivers _DriverInfo;
        private DataTable _dtLocalLicenseHistory;
        private DataTable _dtInternationalLicense;

        public DriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseInfo()
        {
            _dtLocalLicenseHistory = clsDrivers.GetLicenses(_DriverID);

            dataGridView1.DataSource = _dtLocalLicenseHistory;
            lbrecord.Text = dataGridView1.RowCount.ToString();
            _dtLocalLicenseHistory.DefaultView.RowFilter = string.Empty;


            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Lic.ID";

                dataGridView1.Columns[1].HeaderText = "App.ID";

                dataGridView1.Columns[2].HeaderText = "Class Name";

                dataGridView1.Columns[3].HeaderText = "Issue Date";

                dataGridView1.Columns[4].HeaderText = "Expiration Date";

                dataGridView1.Columns[5].HeaderText = "Is Active";
            }
        }

        private void _LoadInternationalLicenseInfo()
        {
            _dtInternationalLicense = clsDrivers.GetInternationalLicenses(_DriverID);

            dataGridView2.DataSource = _dtInternationalLicense;
            lbRecordInternational.Text = dataGridView2.RowCount.ToString();

            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Columns[0].HeaderText = "int.License.ID";

                dataGridView2.Columns[1].HeaderText = "Application ID";

                dataGridView2.Columns[2].HeaderText = "L.License ID";

                dataGridView2.Columns[3].HeaderText = "Issue Date";

                dataGridView2.Columns[4].HeaderText = "Expiration Date";

                dataGridView2.Columns[5].HeaderText = "Is Active";

            }
        }

        public void FillData(int DriverID)
        {
            _DriverID = DriverID;
            _DriverInfo = clsDrivers.FindByDriverID(DriverID);

            if (_DriverInfo == null)
            {
                MessageBox.Show("there is no Driver with id : " + DriverID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        public void FileDataByPersonID(int PersonID)
        {
            _DriverInfo = clsDrivers.FindByPersonID(PersonID);

            if ( _DriverInfo == null)
            {
                MessageBox.Show("there is no Driver with PersonID : " + PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _DriverInfo.DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }
            
        public void Clear()
        {
            _dtInternationalLicense.Clear();
            _dtLocalLicenseHistory.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInternationalDriverInfo frm = new frmInternationalDriverInfo((int)dataGridView2.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showDetilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

    }
}
