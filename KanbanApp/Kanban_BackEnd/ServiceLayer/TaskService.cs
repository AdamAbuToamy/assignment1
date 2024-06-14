using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Kanban_BackEnd.BusinessLayer;
using Microsoft.VisualBasic;

namespace Kanban_BackEnd.ServiceLayer
{
    public class TaskService
    {
        private TaskFacade tf;
        public TaskService(BoardService bs)
        {
            this.tf = bs.gettf();
        }
        public string EditTask (long id,string title,DateTime due_time,string description, string boardname)
        {
            Response response = new Response();
            try
            {
                tf.EditTask(id,title, due_time, description, boardname);
                return JsonSerializer.Serialize(response);
            }
            catch (Exception e)
            {
                response = new Response(e.Message);
                return JsonSerializer.Serialize(response);
            }
        }
        public string UpdateTaskStatus(long id, string boardname)
        {
            Response response = new Response();
            try
            {
                tf.UpdateTaskStatus(id, boardname);
                return JsonSerializer.Serialize(response);
            }
            catch (Exception e)
            {
                response = new Response(e.Message);
                return JsonSerializer.Serialize(response);
            }
        }
        public string CreateTask(string title,DateTime dueDate,string description, string boardname)
        {
            
            Response response=new Response();
            try
            {
                tf.CreateTask(title, dueDate, description, boardname);
                return JsonSerializer.Serialize(response);
            }
            catch (Exception e)
            {
                response = new Response(e.Message);
                return JsonSerializer.Serialize(response);
            }

        }
        public string list_inprogress()
        {
            Response response = new Response();
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions{ WriteIndented = true};

                response = new Response(null, JsonSerializer.Serialize(tf.List_inprogress(), options));
                return JsonSerializer.Serialize(response);
            }
            catch (Exception e)
            {
                response = new Response(e.Message);
                return JsonSerializer.Serialize(response);
            }
        }
    }
}
