using DataLayer.Entities;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface ITasksAccessor
    {
        List<Tasks> GetAll(int userId);
        bool SaveAll(List<Tasks> tasks);
    }
}
