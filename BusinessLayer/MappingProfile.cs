using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Entities;

namespace BusinessLayer
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Tasks, TasksModel>();
                cfg.CreateMap<TasksModel, Tasks>();
            });

            return config;
        }
    }
}
