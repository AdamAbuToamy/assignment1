using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_BackEnd.BusinessLayer
{
    internal class BoardBL
    {
        private string name;
        internal readonly List<TaskBL> backlog;
        internal readonly List<TaskBL> inprogress;
        internal readonly List<TaskBL> done;
        internal int? backlogLimit;
        internal int? inprogressLimit;
        internal int? doneLimit;

        public BoardBL(string name) 
        {
            this.Name = name;
            done = new List<TaskBL>();
            inprogress = new List<TaskBL>();
            backlog = new List<TaskBL>();
        }    
        public string Name
        {
            get => name;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                name = value;
            }
        }

      

        

    }
}
