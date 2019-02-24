using DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface ITasksAccessor
    {
        List<Tasks> GetAll(int userId);
        List<Tasks> SaveAll(List<Tasks> tasks);
        bool Delete(Guid taskId);
    }
}
