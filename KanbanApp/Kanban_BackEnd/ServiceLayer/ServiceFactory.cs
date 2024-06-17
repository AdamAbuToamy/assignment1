using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//using log4net;
//using log4net.Config;
//using System.Reflection;
namespace Kanban_BackEnd.ServiceLayer
{
    internal class ServiceFactory
    {
        
        
        public UserService US;
        public BoardService BS;
        public TaskService TS;
        
        public ServiceFactory(UserService US, BoardService BS,TaskService TS)
        {
            this.US = US;
            this.BS = BS;
            this.TS = TS;
        }
    }
}
