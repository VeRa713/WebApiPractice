namespace WebApiTest.Configuration;

public class ApplicationContext
{
    public List<Dictionary<string, object>> taskList;

    private static ApplicationContext instance = null;

    public static ApplicationContext Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ApplicationContext();
            }

            return instance;
        }
    }

    public ApplicationContext()
    {
        this.taskList = new List<Dictionary<string, object>>();

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

        taskList.Add(task1);
        taskList.Add(task2);
    }
}
