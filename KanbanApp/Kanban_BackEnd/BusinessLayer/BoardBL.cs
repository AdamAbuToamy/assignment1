using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_BackEnd.BusinessLayer
{
    internal class BoardBL
    {
        internal string name;
        internal List<TaskBL> backlog;
        internal List<TaskBL> inprogress;
        internal List<TaskBL> done;
        internal int backlogLimit;
        internal int inprogressLimit;
        internal int doneLimit;


    }
}
