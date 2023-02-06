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

        // newTaskitem.Id = int.Parse(data["id"].ToString());
        // newTaskitem.TaskName = data["task_name"].ToString();
        // newTaskitem.Status = int.Parse(data["status"].ToString());
        // newTaskitem.Priority = int.Parse(data["priority"].ToString());
        // newTaskitem.Desc = data["desc"].ToString();
        // newTaskitem.TeamId = int.Parse(data["team_id"].ToString());

        if (data.ContainsKey("id"))
        {
            newTaskitem.Id = int.Parse(data["id"].ToString());
        }

        if (data.ContainsKey("task_name"))
        {
            newTaskitem.TaskName = data["task_name"].ToString();
        }

        if (data.ContainsKey("status"))
        {
            newTaskitem.Status = int.Parse(data["status"].ToString());
        }

        //if desc is an empty string or does not exist set it to empty
        if (data.ContainsKey("desc"))
        {
            newTaskitem.Desc = data["desc"].ToString();
        }
        else
        {
            newTaskitem.Desc = "";
        }


        //if team id is empty or does not exist set it to unassigned
        if (data.ContainsKey("team_id"))
        {
            newTaskitem.TeamId = int.Parse(data["team_id"].ToString());

        }
        else
        {
            newTaskitem.TeamId = 0; //0 is unassigned so user input should be greated than 0
        }

        if (data.ContainsKey("priority_id"))
        {
            newTaskitem.PriorityId = int.Parse(data["team_id"].ToString());
        }

        return newTaskitem;
    }
}
