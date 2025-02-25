using ContactsBusinessLayer.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DrivingLicenseManagement.Golbal_Classes
{
    internal class clsGlobal
    {
        public static clsUsers CurrentUser = clsUsers.FindByUserID(15);

        public static bool RememberUserNameAndPassword(string userName, string Password)
        {
            string keyPath = "HKEY_CURRENT_USER\\Software\\DrivingLicenseManagement";
            try
            {
                Registry.SetValue(keyPath, "Username", userName);
                Registry.SetValue(keyPath, "Password", Password);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string KetPath = "HKEY_CURRENT_USER\\Software\\DrivingLicenseManagement";
            try
            {
                Username = Registry.GetValue(KetPath, "Username", null) as string;
                Password = Registry.GetValue(KetPath, "Password", null) as string;

                return (Username != null && Password != null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
