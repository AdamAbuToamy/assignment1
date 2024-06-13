using Kanban_BackEnd.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendTests
{
    internal class ChangePasswaord_Test
    {
        UserService userService;
        public ChangePasswaord_Test(UserService userService)
        {
            this.userService = userService;
        }
        public void runTests()
        {

            int passed = 0;
            Console.WriteLine("-----changepassword Tests----\n");

            //-------------valid changepassword test-----------------
            Response response = JsonSerializer.Deserialize<Response>(userService.changePassword("abutoamy@post.bgu.ac.il", "Adam123","Adam111"));
            if (response.ErrorMessage != null)
            {
                Console.WriteLine("Valid credentials test Failed:" + response.ErrorMessage);
                passed--;
            }

            //-------------Wrong changepassword test (unvalid oldpassword)-----------------
            response = JsonSerializer.Deserialize<Response>(userService.changePassword("abutoamy@post.bgu.ac.il", "Adam0","Adam111"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Wrong oldpassword test Failed");
                passed--;
            }

            //-------------Wrong changepassword test (unvalid email)-----------------
            response = JsonSerializer.Deserialize<Response>(userService.changePassword("ahemd@post.bgu.ac.il", "Adam1234","Adam111"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Unexisting email test Failed");
                passed--;
            }

            //-------------Wrong changepassword test (illegal password)-----------------
            response = JsonSerializer.Deserialize<Response>(userService.changePassword("abutoamy@post.bgu.ac.il", "Adam1234", "Adam"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("illegal password test Failed");
                passed--;
            }



            if (passed == 0) Console.WriteLine("All tests passed\n");
        }
    }









}
    

