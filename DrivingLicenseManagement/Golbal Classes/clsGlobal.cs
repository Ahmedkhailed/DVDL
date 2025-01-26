using ContactsBusinessLayer.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement.Golbal_Classes
{
    internal class clsGlobal
    {
        public static clsUsers CurrentUser = clsUsers.FindByUserID(15);

        public static bool RememberUserNameAndPassword(string userName, string Password)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                string filePath = currentDirectory + "\\data.txt";

                if (userName == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                string DataToSave = userName + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(DataToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                string filePath = currentDirectory + "\\data.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            string[] resuilt = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = resuilt[0];
                            Password = resuilt[1];
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
