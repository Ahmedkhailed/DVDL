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
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private int _PersonID = -1;
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.Person; }
        }

        public bool ShowAddPerson
        {
            get { return filter1.ShowAddPerson; }
            set { filter1.ShowAddPerson = value; }
        }

        public delegate void delegateBackData(int PersonId);
        public event delegateBackData BackData;

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                filter1.Enabled = value;
            }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            filter1.FindPersonByPersonID(PersonID);
        }

        private void filter2_OnPersonIdSelected(int SelectedPersonId)
        {
            _PersonID = SelectedPersonId;
            ctrlPersonCard1.LoadPersonInfo(SelectedPersonId);

            BackData?.Invoke(_PersonID);
        }

        public void FilterFocus() => filter1.FilterFocus();
    }
}
