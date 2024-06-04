using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban_BackEnd.BusinessLayer;

namespace Kanban_BackEnd.ServiceLayer
{
    internal class BoardService
    {
        private TaskFacade tf;

        public Response<string> deleteBoard(string name)
        {
            return null;
        }
        public Response<string> createBoard(string name)
        {
            return null;
        }
        public Response<string> LimitColumn(string boardname,string column, int limit)
        {
            return null;
        }

    }
}
