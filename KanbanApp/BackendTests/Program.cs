using Kanban_BackEnd.ServiceLayer;

namespace BackendTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService us = new UserService();

            BoardService bs= new BoardService();
          
            TaskService ts = new TaskService(bs);


            UserSignUp_Test test1 = new UserSignUp_Test(us);
            test1.runTests();

            SignIn_Test test2 = new SignIn_Test(us);
            test2.runTests();

            CreateTask_Test test3 = new CreateTask_Test(ts, bs);
            test3.runTests();

            ChangePasswaord_Test test4 = new ChangePasswaord_Test(us);
            test4.runTests();

            Board_Create_Delete_Limit_Tests test5 = new Board_Create_Delete_Limit_Tests(bs, ts);
            test5.runTests();



        }
    }
}
