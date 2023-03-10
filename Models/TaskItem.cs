namespace WebApiTest.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public int Status { get; set; }
    public string Desc { get; set; }
    public int TeamId { get; set; }
    
    public int PriorityId { get; set; }
    public Priority Priority { get; set; }

    public TaskItem() { }

    // public TaskItem(int id, string taskName, int status, string desc, int teamId, Priority priority)
    // {
    //     Id = id;
    //     TaskName = taskName;
    //     Status = status;
    //     Desc = desc;
    //     TeamId = teamId;
    //     Priority = priority;
    // }
}
