using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban_BackEnd.BusinessLayer;
using Microsoft.VisualBasic;

namespace Kanban_BackEnd.ServiceLayer
{
    internal class TaskService
    {
        private TaskFacade tf;

        public string EditTask (long id,string title,DateTime due_time,string description)
        {
            return null;
        }
        public string UpdateTaskStatus(long id)
        {
            return null;
        }
        public string CreateTask(string title,DateTime dueDate,string description)
        {
            return null;
        }
        public string list_inprogress(string username)
        {
            return null;
        }
    }
}
