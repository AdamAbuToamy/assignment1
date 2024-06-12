using Kanban_BackEnd.ServiceLayer;

namespace BackendTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService us = new UserService();
            BoardService bs= new BoardService();

            UserSignUp_Test test1 = new UserSignUp_Test(us);
            test1.runTests();

            SignIn_Test test2 = new SignIn_Test(us);
            test2.runTests();

            TaskService ts = new TaskService();
            CreateTask_Test test3 = new CreateTask_Test(ts,bs);
            test3.runTests();
        }
    }
}
