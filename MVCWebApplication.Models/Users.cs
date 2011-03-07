using System;

namespace MVCWebApplication.Models
{
    public class User
    {
        private int logonID;
        private string logonName;
        private string password;
        private string emailAddress;
        private DateTime lastLogon;

        public int LogonID
        {
            get { return logonID; }
            set { logonID = value; }
        }

        public string LogonName
        {
            get { return logonName; }
            set { logonName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public DateTime LastLogon
        {
            get { return lastLogon; }
            set { lastLogon = value; }
        }

    }
}
