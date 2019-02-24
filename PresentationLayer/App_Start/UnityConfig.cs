using BusinessLayer;
using BusinessLayer.Services;
using DataLayer.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PresentationLayer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<ITasksService, TasksService>();
            container.RegisterType<ILoginAccessor, LoginAccessor>();
            container.RegisterType<ITasksAccessor, TasksAccessor>();
            container.RegisterType<IEncryption, Encryption>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}