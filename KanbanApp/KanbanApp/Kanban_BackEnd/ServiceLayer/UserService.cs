using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban_BackEnd.BusinessLayer;

namespace Kanban_BackEnd.ServiceLayer
{
    internal class UserService
    {
        private UserFacade uf;


        public Response<UserSL> signin(string username,string password)
        {
            return null;
        }
        public Response<String> changePassword(string username , string oldPassword , string newPassword )
        {
            return null;
        }
        public Response<UserSL> signup(string username, string Password)
        {
            return null;
        }
    }
}
