using Kanban_BackEnd.ServiceLayer;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendTests
{
    internal class list_inprogress_test
    {
        TaskService taskService;
        BoardService boardService;

        public list_inprogress_test(TaskService taskService, BoardService boardService)
        {
            this.taskService = taskService;
            this.boardService = boardService;
        }
        public void runTests()
        {
            int passed = 0;
            Console.WriteLine("-----list inprogress Tests----\n");

            DateTime dueDate = new DateTime(2024, 6, 1);

            boardService.createBoard("board1");
            taskService.CreateTask("task1",dueDate,"","board1");
            taskService.CreateTask("task2", dueDate, "", "board1");
            taskService.UpdateTaskStatus(5, "board1");
            taskService.UpdateTaskStatus(6, "board1");

            boardService.createBoard("board2");
            taskService.CreateTask("task1", dueDate, "", "board2");
            taskService.UpdateTaskStatus(7, "board2");

            boardService.createBoard("board3");
            taskService.CreateTask("taskos", dueDate, "", "board3");
            taskService.UpdateTaskStatus(8, "board3");

            Response response = JsonSerializer.Deserialize<Response>(taskService.list_inprogress());
            Console.WriteLine(response.ReturnValue);

        }
    }
}

