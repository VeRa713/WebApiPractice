using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    public class TaskItemsController : Controller
    {
        //Endpoint to return all taskitems
        //URL: GET /task_items

        //Directives [] additional functionality
        private Dictionary<string, object> data;
        private String payload;

        /*
            {
                "task_items": [
                    { 
                        "id": 1,
                        "task_name": "Task1"
                        "status": 1
                        "priority": 1
                        "desc": "Task 1 Description"
                        "team_id": 1
                    },
                    { 
                        "id": 2,
                        "task_name": "Task2"
                        "status": 3
                        "priority": 3
                        "desc": "Task 2 Description"
                        "team_id": 2
                    }
                ]
            }
            */

        public TaskItemsController()
        {
            data = new Dictionary<string, object>();

            Dictionary<string, object> task1 = new Dictionary<string, object>();
            task1.Add("id", 1);
            task1.Add("task_name", "Task1");
            task1.Add("status", 1);
            task1.Add("priority", 1);
            task1.Add("desc", "Task 1 Description");
            task1.Add("team_id", 1);

            Dictionary<string, object> task2 = new Dictionary<string, object>();
            task2.Add("id", 2);
            task2.Add("task_name", "Task2");
            task2.Add("status", 3);
            task2.Add("priority", 3);
            task2.Add("desc", "Task 2 Description");
            task2.Add("team_id", 2);

            List<object> taskList = new List<object>();
            taskList.Add(task1);
            taskList.Add(task2);

            data.Add("task_items", taskList);

            payload = JsonSerializer.Serialize(data);
        }

        [Route("task_items")]
        public IActionResult Index()
        {
            return Ok(this.payload); //successful request - Status code: 200
        }

        //Endpoint to return a single expense item based on id
        [Route("task_items/{id}")]
        public IActionResult Show(int id)
        {

            List<object> taskList = (List<object>)this.data["task_items"];
            String task;

            foreach (object t in taskList)
            {
                Dictionary<string, object> taskItem = (Dictionary<string, object>)t;

                if (taskItem["id"].Equals(id))
                {
                    return Ok(JsonSerializer.Serialize(t));
                }
            }

            return Ok("Task Item Not Found");
        }
    }
}