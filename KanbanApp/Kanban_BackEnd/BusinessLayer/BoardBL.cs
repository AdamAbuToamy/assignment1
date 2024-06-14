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
        internal readonly Dictionary<long, TaskBL> backlog;
        internal readonly Dictionary<long, TaskBL> inprogress;
        internal readonly Dictionary<long, TaskBL> done;
        internal int? backlogLimit;
        internal int? inprogressLimit;
        internal int? doneLimit;

        public BoardBL(string name) 
        {
            this.Name = name;
            done = new Dictionary<long, TaskBL>();
            inprogress = new Dictionary<long, TaskBL> ();
            backlog = new Dictionary<long, TaskBL>();
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
