using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactsDataAccessLayer;
using ContactsDataAccessLayer.User;

namespace ContactsBusinessLayer.Users
{
    public class clsUsers
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;

            _Mode = enMode.AddNew;
        }

        private clsUsers(int userID, int personID, string userName, string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.Find(personID);
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;

            if (UserID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private bool _UpdateUser() => clsUserData.UpdateUser(UserID, PersonID, UserName, Password, IsActive);

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(PersonID, UserName, Password, IsActive);
            return (this.UserID != -1);
        }

        public static clsUsers FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUsers FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserData.GetUserInfoByPersonID(ref UserID, PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUsers FindByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            if (clsUserData.GetUserByUserNameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
                return _AddNewUser();
            else
                return _UpdateUser();
        }

        public static DataTable GetAllUsers() => clsUserData.GetAllPeople();

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool IsUserExistForPersonID(int PersonID) => clsUserData.IsUserExistForPersonID(PersonID);

        public bool ChangePassword(string OldPassword, string NewPassword) => clsUserData.ChangePassword(this.UserID, OldPassword, NewPassword);

    }
}
