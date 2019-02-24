using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public interface ITasksService
    {
        List<TasksModel> GetAll(int userId);
        List<TasksModel> SaveAll(List<TasksModel> tasks);
        bool Delete(Guid taskId);
    }
}
