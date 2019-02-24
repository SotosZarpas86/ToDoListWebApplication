using BusinessLayer.Models;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITasksService _taskService;

        public HomeController(ITasksService taskService)
        {
            _taskService = taskService;
        }

        public ActionResult Index()
        {
            var user = Session["user"] as UserModel;
            if (user == null)
                return RedirectToAction("Index", "Login");

            var tasksList = Session["taskList"] as List<TasksModel>;
            if (tasksList == null)
            {
                Session["taskList"] = _taskService.GetAll(1);
                tasksList = Session["taskList"] as List<TasksModel>;
            }
            return View(tasksList);
        }

        [HttpGet]
        public ActionResult GetTaskPartial()
        {
            var user = Session["user"] as UserModel;
            if (user == null)
                return RedirectToAction("Index", "Login");

            return PartialView("_AddNewTask", new TasksModel());
        }

        [HttpPost]
        public ActionResult AddRow(TasksModel task)
        {
            var user = Session["user"] as UserModel;
            if (user == null)
                return RedirectToAction("Index", "Login");

            task.TaskID = Guid.NewGuid();
            task.Status = false;
            task.DateAdded = DateTime.Now;
            task.DateUpdated = DateTime.Now;
            var tasksList = Session["taskList"] as List<TasksModel>;
            tasksList.Add(task);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult UpdateRow(Guid id, bool status)
        {
            var tasksList = Session["taskList"] as List<TasksModel>;
            tasksList.SingleOrDefault(t => t.TaskID == id).Status = status;
            tasksList.SingleOrDefault(t => t.TaskID == id).DateUpdated = DateTime.Now;
            return Json(status);
        }

        [HttpPost]
        public JsonResult RemoveRow(Guid id)
        {
            var result = false;
            var tasksList = Session["taskList"] as List<TasksModel>;
            if (tasksList.Remove(tasksList.SingleOrDefault(t => t.TaskID == id)))
                result = true;

            return Json(result);
        }

        [HttpPost]
        public ActionResult SaveAll()
        {
            var user = Session["user"] as UserModel;
            if (user == null)
                return RedirectToAction("Index", "Login");

            var taskList = Session["taskList"] as List<TasksModel>;
            foreach(var item in taskList)
            {
                item.UserId = user.UserID;
            }
            var result = _taskService.SaveAll(taskList);
            return RedirectToAction("Index", "Home");
        }
    }
}