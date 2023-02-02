namespace WebApiTest.Services;

using System.Collections.Generic;
using WebApiTest.Interfaces;
using WebApiTest.Configuration;
using WebApiTest.Models;

public class TaskItemsApplicationContextService : ITaskItemsService

{
    public List<TaskItem> GetAll()
    {
        return ApplicationContext.Instance.taskItemsList;
    }

    public void Save(TaskItem hash) 
    {
        ApplicationContext.Instance.taskItemsList.Add(hash);
    }
    
    public TaskItem Find(int id)
    {
        TaskItem task = ApplicationContext.Instance.taskItemsList.Where(list => list.Id == id).FirstOrDefault();

        return task;
    }

    public void Delete(int id)
    {
        //call find here and then delete
        ApplicationContext.Instance.taskItemsList.Remove(Find(id));
    }
}
