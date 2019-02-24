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
        public bool SaveAll(List<Tasks> tasks)
        {
            var result = false;
            try
            {
                using (var ctx = new ToDoListContext())
                {
                    foreach (var task in tasks)
                    {
                        ctx.Set<Tasks>().AddOrUpdate(task);
                        ctx.Set<Tasks>().AddOrUpdate(task);
                    }
                    ctx.SaveChanges();
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
