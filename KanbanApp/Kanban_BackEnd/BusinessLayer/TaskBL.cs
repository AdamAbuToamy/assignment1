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
            this._title = title;
            this._description = description;
            this._status = "backlog";
            this._dueDate = dueDate;
            this._id = id;
        }

        public long _id { get;}
        public string _title
        {
            get => title;
            set 
            {
                if(value == null)throw new ArgumentNullException("value");
                if (value.Length > 0 && value.Length <= 50) title = value;
                else throw new Exception($"title should be maximum 50 characters and not null!");

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
                if (value.Length <= 300) description = value;
                else throw new Exception("description should be maximum 300 characters!!");
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
