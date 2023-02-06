namespace WebApiTest.Services;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using WebApiTest.Interfaces;
using WebApiTest.Models;
using WebApiTest.Data;
using WebApiTest.Commands;

public class TaskItemsMSSQLService : ITaskItemsService
{
    public readonly DataContext _dataContext;

    public TaskItemsMSSQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public TaskItem Find(int id)
    {
        return _dataContext.TaskItems.SingleOrDefault(o => o.Id == id);
    }

    public List<TaskItem> GetAll()
    {
        return _dataContext.TaskItems.ToList<TaskItem>();
    }

    public void Save(TaskItem task)
    {
        if (task.Id == null || task.Id == 0)
        {
            //insert
            _dataContext.TaskItems.Add(task);
        }
        else
        {
            //update
            TaskItem temp = this.Find(task.Id);
            temp.TaskName = task.TaskName;
            temp.Status = task.Status;
            temp.Desc = task.Desc;
            temp.TeamId = task.TeamId;
            temp.PriorityId = task.PriorityId;
        }

        _dataContext.SaveChanges();
    }
}