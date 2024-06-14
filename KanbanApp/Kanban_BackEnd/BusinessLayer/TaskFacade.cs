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

        
        private long _currentTaskId=1;
        private readonly Dictionary<string, BoardBL> _boards = new Dictionary<string, BoardBL>();
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


        internal TaskBL EditTask(long id, string title, DateTime dueTime, string description, string boardname)
        {
            if(id<0)
            {
                throw new Exception("id is undefined!!");
            }

            TaskBL task;
            if (_boards[boardname].backlog.ContainsKey(id)) task = _boards[boardname].backlog[id];
            else if (_boards[boardname].inprogress.ContainsKey(id)) task = _boards[boardname].inprogress[id];
            else if (_boards[boardname].done.ContainsKey(id)) task = _boards[boardname].done[id];
            else throw new Exception($"no task with this id: {id}");

            if (task._status == "done")
            {
                throw new Exception($"Task that done can't be changed!!");
            }
            else 
            {
                task = new TaskBL(title,description,dueTime,id);
                return task;
            }
        }
        internal void UpdateTaskStatus(long id, string boardname)
        {
            if (_boards[boardname].done.ContainsKey(id)) 
            {
                throw new Exception("this task is done!");
            }
            else if (_boards[boardname].backlog.ContainsKey(id))
            {
                
                _boards[boardname].inprogress.Add(id, _boards[boardname].backlog[id]);
                _boards[boardname].backlog.Remove(id);
                
                _boards[boardname].inprogress[id]._status = "inprogress";
            }
            else if (_boards[boardname].inprogress.ContainsKey(id))
            {
                _boards[boardname].done.Add(id, _boards[boardname].inprogress[id]);
                _boards[boardname].inprogress.Remove(id);

                _boards[boardname].done[id]._status = "done";
            }
            else throw new Exception("no task with this id!");
        }

        internal TaskBL CreateTask(string title,DateTime dueDate,string description,string boardname)
        {

            if (_boards[boardname].backlogLimit == null || _boards[boardname].backlog.Count < _boards[boardname].backlogLimit) 
            {
                    TaskBL task = new TaskBL(title, description, dueDate, _currentTaskId);
                    _boards[boardname].backlog.Add(_currentTaskId,task);
                    _currentTaskId++;
                    return task;
            }
            else
            {
                throw new Exception($"backlog limit is full!! cant add task!");
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
        internal List<TaskBL> List_inprogress()
        {
            List <TaskBL> returnList = new List<TaskBL>();

            foreach (KeyValuePair<string, BoardBL> board in _boards)
            {
                foreach (KeyValuePair<long, TaskBL> task in board.Value.inprogress) 
                {
                    returnList.Add(task.Value);
                }
            }

            return returnList;
        }




    }
}
