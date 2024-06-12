using Kanban_BackEnd.ServiceLayer;

namespace BackendTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService us = new UserService();

            UserSignUp_Test test1 = new UserSignUp_Test(us);
            test1.runTests();

            SignIn_Test test2 = new SignIn_Test(us);
            test2.runTests();

            ChangePasswaord_Test test3 = new ChangePasswaord_Test(us);
            test3.runTests();
        }
    }
}
