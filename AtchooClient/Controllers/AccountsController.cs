using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AtchooClient.Models;
using AtchooClient.ViewModels;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace AtchooClient.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            ApplicationUser.Register(model);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            string userId = ApplicationUser.Login(model);
            HttpContext.Session.SetString("userId", userId);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}