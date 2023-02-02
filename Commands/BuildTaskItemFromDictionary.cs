namespace WebApiTest.Commands;

using WebApiTest.Models;
using System.Text.Json;

public class BuildTaskItemFromDictionary
{
    private Dictionary<string, object> data;

    // 1 - Constructor that passes all inputs required
    public BuildTaskItemFromDictionary(Dictionary<string, object> hash)
    {
        this.data = hash;
    }

    // 2 - Executable Method. Like its own Main method
    public TaskItem Execute()
    {
        TaskItem newTaskitem = new TaskItem();

        newTaskitem.Id = int.Parse(data["id"].ToString());
        newTaskitem.TaskName = data["task_name"].ToString();
        newTaskitem.Status = int.Parse(data["status"].ToString());
        newTaskitem.Priority = int.Parse(data["priority"].ToString());
        newTaskitem.Desc = data["desc"].ToString();
        newTaskitem.TeamId = int.Parse(data["team_id"].ToString());

        return newTaskitem;
    }
}
