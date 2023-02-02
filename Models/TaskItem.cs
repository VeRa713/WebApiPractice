namespace WebApiTest.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public int Status { get; set; }
    public int Priority { get; set; }
    public string Desc { get; set; }
    public int TeamId { get; set; }

    public TaskItem(int id, string taskName, int status, int priority, string desc, int teamId)
    {
        Id = id;
        TaskName = taskName;
        Status = status;
        Priority = priority;
        Desc = desc;
        TeamId = teamId;
    }
}
