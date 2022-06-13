using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using AtchooClient.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace AtchooClient.Controllers
{
  public class UserProfileController : Controller
  {
    public ActionResult Index()
    {
      if(string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
      {
        return RedirectToAction("Login", "Accounts");
      }
      return View();
    }
  }
}