using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Kanban_BackEnd.BusinessLayer;

namespace Kanban_BackEnd.ServiceLayer
{
    public class BoardService
    {
        private TaskFacade tf;

        public BoardService()
        {
            tf = new TaskFacade();
        }

        public string deleteBoard(string name)
        {
            Response response = new Response();
            try
            {
                tf.deleteBoard(name);
                return JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                response = new Response(ex.Message);
                return JsonSerializer.Serialize(response);
            }
        }
        public string createBoard(string name)
        {
            Response response = new Response();
            try
            {
                tf.createBoard(name);
                return JsonSerializer.Serialize(response);
            }
            catch(Exception ex)
            {
                response = new Response(ex.Message);
                return JsonSerializer.Serialize(response);
            }
        }
        public string LimitColumn(string boardname,string column, int limit)
        {
            Response response = new Response();
            try
            {
                tf.LimitColumn(boardname,column,limit);
                return JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                response = new Response(ex.Message);
                return JsonSerializer.Serialize(response);
            }
        }

    }
}
