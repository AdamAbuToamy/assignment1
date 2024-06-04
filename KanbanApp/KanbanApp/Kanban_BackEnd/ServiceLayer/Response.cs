using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_BackEnd.ServiceLayer
{
    internal class Response<T>
    {
        public Object ResponseValue;
        public string ErrorMessage;
    }
}
