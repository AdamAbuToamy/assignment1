using Kanban_BackEnd.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendTests
{
    internal class updateTaskStatus_test
    {
        TaskService taskservice;
        public updateTaskStatus_test(TaskService taskService)
        {
            this.taskservice = taskService;
        }
        public void runTests()
        {
            int passed = 0;
            Console.WriteLine("-----update task status Tests----\n");

            DateTime dueDate = new DateTime(2024, 6, 1);
            taskservice.CreateTask("StatusUpdate", dueDate, "", "board1");

            //-------------valid status update test-----------------
            Response response = JsonSerializer.Deserialize<Response>(taskservice.UpdateTaskStatus(9, "board1"));
            response = JsonSerializer.Deserialize<Response>(taskservice.UpdateTaskStatus(9, "board1"));
            if (response.ErrorMessage != null)
            {
                Console.WriteLine("Valid status update Failed:" + response.ErrorMessage);
                passed--;
            }

            //-------------done status update test-----------------
            response = JsonSerializer.Deserialize<Response>(taskservice.UpdateTaskStatus(9, "board1"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("done status update test Failed");
                passed--;
            }

            //-------------unexisted id status update test-----------------
            response = JsonSerializer.Deserialize<Response>(taskservice.UpdateTaskStatus(200, "board1"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("unexisted id status update test Failed");
                passed--;
            }

            if (passed == 0) Console.WriteLine("All tests passed\n");



        }
    }
}