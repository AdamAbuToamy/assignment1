using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_BackEnd.BusinessLayer
{
    internal class UserFacade
    {
        internal Dictionary<string, UserBL> users;

        internal UserBL Signin(string username,string password)
        {
            return null;
        }
        internal void ChangePassword(string username,string oldPassword,string newPassword)
        {
            ;
        } 
        internal bool IsLoggedIn(string username)
        {
            return false;
        }
    }
}
