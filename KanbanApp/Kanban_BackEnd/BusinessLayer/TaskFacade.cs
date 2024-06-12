using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Kanban_BackEnd.BusinessLayer
{
    internal class TaskFacade
    {
        Dictionary<string, BoardBL> boards;

        internal void deleBoard(string boardName)
        {
            ;
        }
        internal void LimitColumn(string boardName, string column, int Limit)
        {
            ;
        }
        internal TaskBL EditTask(long id, string title, DateTime dueTime, string description)
        {
            return null;
        }
        internal void UpdateTaskStatus(long id)
        {
            ;
        }
        internal TaskBL CreateTask(string title,DateTime dueDate,string description)
        {
            return null;
        }
        internal BoardBL createBoard(string boardname)
        {
            return null;
        }
        internal List<TaskBL> List_inprogress(long id)
        {
            return null;
        }




    }
}
