namespace WebApiTest.Controllers;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Interfaces;


// base route = task_items/HttpGet
[ApiController]
[Route("task_items")]
public class TaskItemsController : ControllerBase
{
    //Endpoint to return all taskitems
    //URL: GET /task_items

    //Directives [] additional functionality
    private readonly ITaskItemsService _taskItemsService;

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

    public TaskItemsController(ITaskItemsService taskItemsService)
    {
        _taskItemsService = taskItemsService;
    }


    [HttpGet("")]
    public IActionResult Index()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();

        data.Add("task_items", _taskItemsService.GetAll());

        return Ok(data);
    }

    //Endpoint to return a single expense item based on id
    //to transfer search in service
    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {

        var taskList = _taskItemsService.GetAll();

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

        _taskItemsService.Save(newTask);

        Dictionary<string, object> message = new Dictionary<string, object>();
        message.Add("message", "OK");

        return Ok(message);
    }
}
