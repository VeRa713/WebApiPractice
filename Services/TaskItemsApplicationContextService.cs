namespace WebApiTest.Services;

using System.Collections.Generic;
using WebApiTest.Interfaces;
using WebApiTest.Configuration;

public class TaskItemsApplicationContextService : ITaskItemsService

{
    public List<Dictionary<string, object>> GetAll()
    {
        return ApplicationContext.Instance.taskList;
    }

    public void Save(Dictionary<string, object> hash)
    {
        ApplicationContext.Instance.taskList.Add(hash);
    }
}
