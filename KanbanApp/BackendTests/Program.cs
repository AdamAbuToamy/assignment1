using Kanban_BackEnd.ServiceLayer;

namespace BackendTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService us = new UserService();
            UserSignUp_Test test = new UserSignUp_Test(us);
            test.runTests();
        }
    }
}
