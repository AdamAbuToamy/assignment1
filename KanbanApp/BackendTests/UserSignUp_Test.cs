using Kanban_BackEnd.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendTests
{
    internal class UserSignUp_Test
    {
        UserService userService;
        public UserSignUp_Test(UserService userService)
        {
            this.userService = userService;
        }
        public void runTests()
        {
            int passed = 0;
            Console.WriteLine("-----SignUp Tests----\n");

            //-------------valid signup test-----------------
            Response response = JsonSerializer.Deserialize<Response>(userService.signup("adam abu toamy", "abutoamy@post.bgu.ac.il", "Adam123"));
            if (response.ErrorMessage != null)
            {
                Console.WriteLine("Valid credentials test Failed:" + response.ErrorMessage);
                passed--;
            }

            //-------------existing email test-----------------
            response = JsonSerializer.Deserialize<Response>(userService.signup("ahmed", "abutoamy@post.bgu.ac.il", "Aa1aa1"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Existing email test Failed");
                passed--;
            }

            //-------------non valid password test-----------------
            response = JsonSerializer.Deserialize<Response>(userService.signup("ahmed", "ahmed@post.bgu.ac.il", "ahmed1ahmed"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Valid password test1(no uppercase letter) Failed");
                passed--;
            }
            response = JsonSerializer.Deserialize<Response>(userService.signup("ahmed", "ahmed@post.bgu.ac.il", "AHMED1AHMED"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Valid password test2(no lowercase letter) Failed");
                passed--;
            }
            response = JsonSerializer.Deserialize<Response>(userService.signup("ahmed", "ahmed@post.bgu.ac.il", "Ahmd1"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Valid password test3(short password) Failed");
                passed--;
            }
            response = JsonSerializer.Deserialize<Response>(userService.signup("ahmed", "ahmed@post.bgu.ac.il", "Ahmed1ahmedahmedahmed1"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Valid password test4(long password) Failed");
                passed--;
            }
            response = JsonSerializer.Deserialize<Response>(userService.signup("ahmed", "ahmed@post.bgu.ac.il", "AhmedAhmed"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Valid password test5(no number) Failed");
                passed--;
            }

            //-------------null username test-----------------
            response = JsonSerializer.Deserialize<Response>(userService.signup("", "ahmed@post.bgu.ac.il", "AhmedAhmed"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Null username test Failed");
                passed--;
            }

            //-------------null email test-----------------
            response = JsonSerializer.Deserialize<Response>(userService.signup("ahmed", "", "AhmedAhmed"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Null email test Failed");
                passed--;
            }

            if (passed == 0) Console.WriteLine("All tests passed");
            Console.WriteLine("\n---------------------\n");

        }
    }
}
