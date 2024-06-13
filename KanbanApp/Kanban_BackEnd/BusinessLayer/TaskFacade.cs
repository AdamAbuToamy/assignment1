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

        
        private long _currentTaskId=0;
        private readonly Dictionary<string, BoardBL> _boards = new Dictionary<string, BoardBL>();
        private readonly Dictionary<long, TaskBL> _alltasks = new Dictionary<long, TaskBL>();
        internal void deleteBoard(string boardName)
        {
            if (_boards.ContainsKey(boardName))
            {
                _boards[boardName] = null;
                _boards.Remove(boardName);
            }
            else throw new KeyNotFoundException($"A board with name {boardName} is not existed!");
        }


        internal void LimitColumn(string boardName, string column, int Limit)
        {
            if (column == "backlog")
            {
                if (Limit < _boards[boardName].backlog.Count) 
                {
                    throw new ArgumentOutOfRangeException("Backlog column contain more task than the givven limit!");
                }
                _boards[boardName].backlogLimit = Limit;
            }
            else if (column == "inprogress")
            {
                if (Limit < _boards[boardName].inprogress.Count)
                {
                    throw new ArgumentOutOfRangeException("Inprogress column contain more task than the givven limit!");
                }
                _boards[boardName].inprogressLimit = Limit;
            }
            else if (column == "done")
            {
                if (Limit < _boards[boardName].done.Count)
                {
                    throw new ArgumentOutOfRangeException("Done column contain more task than the givven limit!");
                }
                _boards[boardName].doneLimit = Limit;
            }
            else throw new Exception($"No column named: {column}");
        }


        internal TaskBL EditTask(long id, string title, DateTime dueTime, string description)
        {
            if(id<0)
            {
                throw new Exception("id is undefined!!");
            }
            TaskBL toBeEdited = _alltasks[id];
            if (toBeEdited._status == "done")
            {
                throw new Exception($"Task that done can't be changed!!");
            }
            else if ((title.Length > 0 && title.Length <= 50) && description.Length <= 300)
            {
                toBeEdited._title = title;
                toBeEdited._description = description;
                toBeEdited._dueDate = dueTime;
                return toBeEdited;
            }
            else
            {
                throw new Exception($"title should be maximum 50 characters, not empty,and description should be maximum 300 characters!!");
            }
        }
        internal void UpdateTaskStatus(long id)
        {
            ;
        }
        internal TaskBL CreateTask(string title,DateTime dueDate,string description,string boardname)
        {

            if (_boards[boardname].backlogLimit == null || _boards[boardname].backlog.Count < _boards[boardname].backlogLimit) 
            {
                if ((title.Length>0 && title.Length <= 50) && description.Length <= 300)
                {
                    TaskBL task = new TaskBL(title, description, dueDate, _currentTaskId);
                    _alltasks.Add(_currentTaskId, task);
                    _boards[boardname].backlog.Add(task);
                    _currentTaskId++;
                    return task;
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
            if (_boards.ContainsKey(boardname))
            {
                throw new Exception($"Board {boardname} already exists");
            }
            BoardBL board = new BoardBL(boardname);
            _boards.Add(boardname, board);
            return board;
        }
        internal List<TaskBL> List_inprogress(long id)
        {
            return null;
        }




    }
}
