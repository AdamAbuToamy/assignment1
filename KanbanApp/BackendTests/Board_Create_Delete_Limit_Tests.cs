using Kanban_BackEnd.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendTests
{
    internal class Board_Create_Delete_Limit_Tests
    {
        BoardService boardservice;
        TaskService taskservice;
        public Board_Create_Delete_Limit_Tests(BoardService boardservice, TaskService taskService)
        {
            this.boardservice = boardservice;
            this.taskservice = taskService;
        }
        public void runTests()
        {
            int passed = 0;
            Console.WriteLine("-----Board Creation Tests----\n");

            //-------------valid creation test-----------------
            Response response = JsonSerializer.Deserialize<Response>(boardservice.createBoard("FriendsBoard"));
            if (response.ErrorMessage != null)
            {
                Console.WriteLine("Valid creation test Failed:" + response.ErrorMessage);
                passed--;
            }

            //-------------existing board test-----------------
            response = JsonSerializer.Deserialize<Response>(boardservice.createBoard("FriendsBoard"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Existing board test Failed");
                passed--;
            }

            if (passed == 0) Console.WriteLine("All tests passed\n");



            passed = 0;
            Console.WriteLine("-----Board Creation Tests----\n");

            //-------------board delete test-----------------
            response = JsonSerializer.Deserialize<Response>(boardservice.deleteBoard("FriendsBoard"));
            if (response.ErrorMessage != null)
            {
                Console.WriteLine("Board delete test Failed:" + response.ErrorMessage);
                passed--;
            }

            //-------------unexisting board delete test-----------------
            response = JsonSerializer.Deserialize<Response>(boardservice.deleteBoard("FriendsBoard"));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Unexisting board delete test Failed");
                passed--;
            }

            if (passed == 0) Console.WriteLine("All tests passed\n");



            passed = 0;
            Console.WriteLine("-----Columns Limit Tests----\n");

            //-------------valid limit test-----------------
            boardservice.createBoard("FriendsBoard");
            response = JsonSerializer.Deserialize<Response>(boardservice.LimitColumn("FriendsBoard", "backlog", 5));
            if (response.ErrorMessage != null)
            {
                Console.WriteLine("Valid limit test Failed:" + response.ErrorMessage);
                passed--;
            }

            //-------------unexisting column limit test-----------------
            response = JsonSerializer.Deserialize<Response>(boardservice.LimitColumn("FriendsBoard", "col", 5));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Unexisting column limit test Failed");
                passed--;
            }

            //-------------unexisting board limit test-----------------
            response = JsonSerializer.Deserialize<Response>(boardservice.LimitColumn("NoBoard", "done", 5));
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("Unexisting board limit test Failed");
                passed--;
            }

            //-------------limit smaller than tasks on column test-----------------
            //DateTime time = new DateTime(2024, 6, 12, 14, 30, 0);
            //taskservice.CreateTask("one", time, "bs esm3 mnni", "FriendsBoard");
            //taskservice.CreateTask("one", time, "bs esm3 mnni", "FriendsBoard");
            //taskservice.CreateTask("one", time, "bs esm3 mnni", "FriendsBoard");
            //response = JsonSerializer.Deserialize<Response>(boardservice.LimitColumn("FriendsBoard", "done", 2));
            //if (response.ErrorMessage == null)
            //{
            //    Console.WriteLine("Limit smaller than tasks on column test Failed");
            //    passed--;
            //}

            if (passed == 0) Console.WriteLine("All tests passed\n");


        }
    }
}
