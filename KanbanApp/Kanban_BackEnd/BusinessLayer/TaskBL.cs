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
        readonly private long id;//we dont want that id can be changed.
        private string title;
        private DateTime dueDate;
        private string description;
        readonly private DateTime createTime;//can't be changed.
        private string status;
        

        public TaskBL(string title,string description,DateTime dueDate,long id)
        {
            createTime = DateTime.Now;
            this.title = title;
            this.description = description;
            this.status = "backlog";
            this.dueDate = dueDate;
            this.id = id;
        }
        public long getId() { return id; }
        public string _title
        {
            get => title;
            set 
            {
                if(value == null)throw new ArgumentNullException("value");
                title = value;
            }
        }
        public DateTime _dueDate
        {
            get => dueDate;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                dueDate = value;
            }
        }
        public string _description
        {
            get => description;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                description = value;
            }
        }
        public string _status
        {
            get => status;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                status = value;
            }
        }
    }
}
