using BusinessLayer.Models;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            if(string.IsNullOrWhiteSpace(user.Username) && string.IsNullOrWhiteSpace(user.Password))
            {
                return View("Index");
            }
            var result = _loginService.Login(user);
            if(result.UserID != 0)
            {
                Session["user"] = result;
                Session["taskList"] = result.Tasks;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}