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
            var taskDb = _taskAccessor.GetAll(userId);
            var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            var taskBs = mapper.Map<List<Tasks>, List<TasksModel>>(taskDb);
            return taskBs;
        }
        public bool SaveAll(List<TasksModel> tasks)
        {
            var result = false;
            var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            var taskDb = mapper.Map<List<TasksModel>, List<Tasks>>(tasks);
            result = _taskAccessor.SaveAll(taskDb);
            return result;
        }
    }
}
