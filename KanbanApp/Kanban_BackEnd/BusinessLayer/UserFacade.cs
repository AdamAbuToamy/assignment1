using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_BackEnd.BusinessLayer
{
    internal class UserFacade
    {
        private readonly Dictionary<string, UserBL> _users = new Dictionary<string, UserBL>();

        internal UserBL Signin(string username,string password)
        {
            return null;
        }
        internal void ChangePassword(string username,string oldPassword,string newPassword)
        {
            
        } 
        internal bool IsLoggedIn(string username)
        {
            return false;
        }

        public void signup(string username, string email, string password)
        {
            if (_users.ContainsKey(email))
            {
                throw new Exception($"Email {email} already exists");
            }
            UserBL user = new UserBL(username, email, password);
            _users.Add(email, user);
        }
    }
}
