using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Kanban_BackEnd.BusinessLayer
{
    internal class TaskFacade
    {
        private readonly Dictionary<string, BoardBL> _boards;
        private long _currentTaskId=0;
        

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
        internal TaskBL CreateTask(string title,DateTime dueDate,string description,string boardname)
        {
            if (_boards[boardname] == null || _boards[boardname].backlog.Count < _boards[boardname].backlogLimit) 
            {
                if ((title.Length>0 & title.Length <= 50) && description.Length <= 300)
                {
                    TaskBL taskbl = new TaskBL(title, description, dueDate, _currentTaskId++);
                    _boards[boardname].backlog.Add(taskbl);
                    return taskbl;
                }
                else
                {
                    throw new Exception($"title should be maximum 50 characters, not empty,and description should be maximum 300 characters!!");
                }
               
            }
            else
            {
                throw new Exception($"board is full!! cant add task!");
            }
            
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
