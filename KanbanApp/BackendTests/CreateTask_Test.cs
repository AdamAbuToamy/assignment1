using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Kanban_BackEnd.ServiceLayer;

namespace BackendTests
{
    internal class CreateTask_Test
    {
        TaskService taskService;
        BoardService boardService;
        public CreateTask_Test(TaskService taskservice, BoardService boardService)
        {
            this.taskService = taskservice;
            this.boardService = boardService;
        }
        
        public void runTests()
        {
            int passed = 0;
            Console.WriteLine("-----CreateTask Tests----\n");

            //-------------valid createTask test------------------

            //boardService.createBoard("assignments");
            //Response response = JsonSerializer.Deserialize<Response>(taskService.CreateTask("solve assignment1",new DateTime(2024,6,1,13,50,30),"do assignment before sunday","assignments"));
            //if (response.ErrorMessage != null)
            //{
            //    Console.WriteLine("Valid task data test Failed:" + response.ErrorMessage);
            //    passed--;
            //}


            //-------------WrongData createTask test-----------------

            
            //Response response = JsonSerializer.Deserialize<Response>(taskService.CreateTask("solve assignment1", new DateTime(2024, 6, 1, 13, 50, 30), "do assignment before sunday", "assignments"));
            //if (response.ErrorMessage == null)
            //{
            //    Console.WriteLine("WrongData test Failed:" + response.ErrorMessage);
            //    passed--;
            //}

            //-------------fullBoardError createTask test-----------------

            
            //boardService.LimitColumn("assignments", "backlog", 0);
            //response = JsonSerializer.Deserialize<Response>(taskService.CreateTask("solve assignment1", new DateTime(2024, 6, 1, 13, 50, 30), "do assignment before sunday", "assignments"));
            //if (response.ErrorMessage == null)
            //{
            //    Console.WriteLine("WrongData test Failed:" + response.ErrorMessage);
            //    passed--;
            //}




            if (passed == 0) Console.WriteLine("All tests passed\n");
        }
    }
}
