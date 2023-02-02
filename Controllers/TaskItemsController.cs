namespace WebApiTest.Controllers;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

// base route = task_items/HttpGet
[ApiController]
[Route("task_items")]
public class TaskItemsController : ControllerBase
{
    //Endpoint to return all taskitems
    //URL: GET /task_items

    //Directives [] additional functionality
    private Dictionary<string, object> data;
    List<object> taskList;
    private String serializedData;

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

        taskList = new List<object>();
        taskList.Add(task1);
        taskList.Add(task2);

        data.Add("task_items", taskList);
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        this.serializedData = JsonSerializer.Serialize(data);
        return Ok(this.serializedData); //successful request - Status code: 200
    }

    //Endpoint to return a single expense item based on id
    [HttpGet("{id}")]
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

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        // curl -X POST -H "Content-Type: application/json" -d @payloads/taskItem.json http://localhost:5003/task_items | jq
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        int id = int.Parse(hash["id"].ToString());
        string task_name = hash["task_name"].ToString();
        int status = int.Parse(hash["status"].ToString());
        int priority = int.Parse(hash["priority"].ToString());
        string desc = hash["desc"].ToString();
        int team_id = int.Parse(hash["team_id"].ToString());

        Console.WriteLine("Task: " + task_name);

        Dictionary<string, object> newTask = new Dictionary<string, object>();
        newTask.Add("id", id);
        newTask.Add("task_name", task_name);
        newTask.Add("status", status);
        newTask.Add("priority", priority);
        newTask.Add("desc", desc);
        newTask.Add("team_id", team_id);

        //add newTask to list then to dictionary
        taskList.Add(newTask);

        Console.WriteLine("NewTaskList: " + taskList.Count());

        this.data["task_items"] = taskList;

        var s = ((Dictionary<string, object>)(((List<object>)(this.data["task_items"]))[2]))["task_name"];
        Console.WriteLine("NewTask: " + s.ToString());

        Dictionary<string, object> message = new Dictionary<string, object>();
        message.Add("message", "OK");

        return Ok(message);
    }
}
