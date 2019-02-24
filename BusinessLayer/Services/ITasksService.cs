using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public interface ITasksService
    {
        List<TasksModel> GetAll(int userId);
        bool SaveAll(List<TasksModel> tasks);
    }
}
