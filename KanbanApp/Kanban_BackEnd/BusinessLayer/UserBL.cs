using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kanban_BackEnd.BusinessLayer
{
    internal class UserBL
    {
        private string username;
        private string email;
        private string password;
        internal bool LoggedIn = true;

        
        public UserBL(string username, string email, string password)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }

        public string Email
        {
            get => email;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                email = value;
            }
        }
       
        public string Username
        {
            get => username;
            set 
            {
                if (value == null) throw new ArgumentNullException("value");
                username = value;
            }
        }

        internal string Password
        {
            get => password;
            set
            {
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[^\s]{6,20}$";
                if(Regex.IsMatch(value, pattern)) password = value;
                else throw new ArgumentException("Password does not meet the requirements.");
              
            }
        }
    }
}
