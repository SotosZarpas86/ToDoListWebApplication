using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksAccessor _taskAccessor;

        public TasksService(ITasksAccessor taskAccessor)
        {
            _taskAccessor = taskAccessor;
        }

        public List<TasksModel> GetAll(int userId)
        {
            var tasksBs = new List<TasksModel>();
            try
            {
                var tasksDb = _taskAccessor.GetAll(userId);
                var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
                tasksBs = mapper.Map<List<Tasks>, List<TasksModel>>(tasksDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tasksBs;
        }
        public List<TasksModel> SaveAll(List<TasksModel> tasks)
        {
            try
            {
                var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
                var taskDb = mapper.Map<List<TasksModel>, List<Tasks>>(tasks);
                var result = _taskAccessor.SaveAll(taskDb);
                tasks = mapper.Map<List<Tasks>, List<TasksModel>>(result);
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
                result = _taskAccessor.Delete(taskId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
