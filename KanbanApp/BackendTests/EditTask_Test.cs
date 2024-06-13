using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Kanban_BackEnd.ServiceLayer;

namespace BackendTests
{
    internal class EditTask_Test
    {
        TaskService taskService;
        

        public EditTask_Test(TaskService taskService)
        {
            this.taskService = taskService;
            
        }
        public void runTests()
        {
            int passed = 0;
            Console.WriteLine("-----EditTask Tests----\n");

            //-------------valid EditTask test------------------

            Response response = JsonSerializer.Deserialize<Response>(taskService.EditTask(1,"gym day1",new DateTime(2024,7,5,12,0,0),"camoon!"));
            if (response.ErrorMessage != null)
            {
                Console.WriteLine("Valid task data test Failed:" + response.ErrorMessage);
                passed--;
            }


            //-------------WrongData EditTask test(wrong id)-----------------


            response = JsonSerializer.Deserialize<Response>(taskService.EditTask(-1,"gym day2", new DateTime(2024, 7, 5, 12, 0, 0), ""));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("WrongData test Failed:" + response.ErrorMessage);
                passed--;
            }

            //-------------WrongData EditTask test(wrong title)-----------------


            
            response = JsonSerializer.Deserialize<Response>(taskService.EditTask(142,"", new DateTime(2024, 7, 5, 12, 0, 0), ""));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("WrongData test Failed:" + response.ErrorMessage);
                passed--;
            }

            



            if (passed == 0) Console.WriteLine("All tests passed\n");
        }
    }
}
