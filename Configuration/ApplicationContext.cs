namespace WebApiTest.Configuration;

using WebApiTest.Models;

public class ApplicationContext
{
    public List<TaskItem> taskItemsList;
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
        this.taskItemsList = new List<TaskItem>();

        TaskItem task1 = new TaskItem(1, "Task1", 1, 1, "Non-priority Task", 1);
        TaskItem task2 = new TaskItem(2, "Task2", 3, 3, "Urgent Task!", 2);

        taskItemsList.Add(task1);
        taskItemsList.Add(task2);
    }
}
