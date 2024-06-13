using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Kanban_BackEnd.BusinessLayer;

namespace Kanban_BackEnd.ServiceLayer
{
    public class UserService
    {
        private UserFacade uf;
        public UserService()
        {
            this.uf = new UserFacade();
        }

        public string signin(string email,string password)
        {
            Response response = new Response();
            try
            {
                uf.signin(email, password);
                return JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                response = new Response(ex.Message);
                return JsonSerializer.Serialize(response);
            }
        }
        public string changePassword(string email , string oldPassword , string newPassword )
        {
            Response response = new Response();
            try
            {
                uf.ChangePassword(email, oldPassword,newPassword);
                return JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                response = new Response(ex.Message);
                return JsonSerializer.Serialize(response);
            }
        }
        public string signup(string username, string email, string Password)
        {
            Response response = new Response();
            try
            {
                uf.signup(username, email, Password);
                return JsonSerializer.Serialize(response);
            }
            catch(Exception ex)
            {
                response = new Response(ex.Message);
                return JsonSerializer.Serialize(response);
            }
            
        }
    }
}
