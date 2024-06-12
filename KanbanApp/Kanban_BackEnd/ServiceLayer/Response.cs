using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_BackEnd.ServiceLayer
{
    public class Response
    {
        public string? ErrorMessage { get; set; }
        public string? ReturnValue { get; set; }
        public bool isError { get => ErrorMessage != null; }
        public Response() { }
        public Response(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ReturnValue = null;
        }
        public Response(string errorMessage, string returnValue)
        {
            ErrorMessage = errorMessage;
            ReturnValue = returnValue;
        }
    }
}
