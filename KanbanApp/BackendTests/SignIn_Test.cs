using Kanban_BackEnd.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendTests
{
    internal class SignIn_Test
    {
        UserService userService;
        public SignIn_Test(UserService userService)
        {
            this.userService = userService;
        }
        public void runTests() 
        {
            int passed = 0;
            Console.WriteLine("-----SignIn Tests----\n");

            //-------------valid signin test-----------------
            Response response = JsonSerializer.Deserialize<Response>(userService.signin("abutoamy@post.bgu.ac.il", "Adam123"));
            if (response.ErrorMessage != null)
            {
                Console.WriteLine("Valid credentials test Failed:" + response.ErrorMessage);
                passed--;
            }

            //-------------Wrong password test-----------------
            response = JsonSerializer.Deserialize<Response>(userService.signin("abutoamy@post.bgu.ac.il", "Adam1234"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Wrong password test Failed");
                passed--;
            }

            //-------------Unexisting email test-----------------
            response = JsonSerializer.Deserialize<Response>(userService.signin("ahemd@post.bgu.ac.il", "Adam1234"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Unexisting email test Failed");
                passed--;
            }

  

            if (passed == 0) Console.WriteLine("All tests passed\n");
        }
    }
}
