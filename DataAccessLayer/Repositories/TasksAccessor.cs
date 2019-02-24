using DataAccessLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataLayer.Repositories
{
    public class TasksAccessor : ITasksAccessor
    {
        public List<Tasks> GetAll(int userId)
        {
            var result = new List<Tasks>();
            try
            {
                using (var ctx = new ToDoListContext())
                {
                    result = ctx.Tasks.Where(t => t.UserId == userId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public List<Tasks> SaveAll(List<Tasks> tasks)
        {
            try
            {
                using (var ctx = new ToDoListContext())
                {
                    foreach (var task in tasks)
                    {
                        var result = ctx.Tasks.SingleOrDefault(t => t.ID == task.ID);
                        if(result == null)
                            ctx.Tasks.Add(task);
                        else
                            ctx.Entry(result).CurrentValues.SetValues(task);
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tasks;
        }

        public bool Delete(Guid taskId)
        {
            var result = false;
            try
            {
                using (var ctx = new ToDoListContext())
                {
                    var task = ctx.Tasks.SingleOrDefault(t => t.TaskID == taskId);
                    if(task != null)
                        ctx.Tasks.Remove(task);

                    ctx.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
