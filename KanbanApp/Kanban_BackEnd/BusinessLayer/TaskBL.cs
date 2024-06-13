using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_BackEnd.BusinessLayer
{
    internal class TaskBL
    {
        internal long id;
        internal string title;
        internal DateTime dueDate;
        internal string description;
        internal DateTime createTime;
        internal string status;
        
        public TaskBL(string title,string description,DateTime dueDate,long id)
        {
            createTime = DateTime.Now;
            this.title = title;
            this.description = description;
            this.status = "To do";
            this.dueDate = dueDate;
            this.id = id;
        }


    }
}
