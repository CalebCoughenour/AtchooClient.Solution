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
    private readonly AtchooClientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserProfileController(UserManager<ApplicationUser> userManager, AtchooClientContext db)
    {
      _userManager = userManager;
      _db = db;
    } 
  }
}