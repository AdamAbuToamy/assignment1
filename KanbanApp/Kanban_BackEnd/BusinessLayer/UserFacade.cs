using Kanban_BackEnd.ServiceLayer;
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

        internal UserBL signin(string email,string password)
        {
            if (_users.ContainsKey(email) && _users[email].Password == password) 
            {
                _users[email].LoggedIn = true;
                return _users[email];
            }
            throw new Exception("Wrong credentials!");

        }
        internal void ChangePassword(string username,string oldPassword,string newPassword)
        {
            
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
