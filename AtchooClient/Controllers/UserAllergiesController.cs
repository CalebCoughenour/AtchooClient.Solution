using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AtchooClient.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AtchooClient.Controllers
{
    
    public class UserAllergiesController : Controller
  {
    private readonly AtchooClientContext _db;

    public UserAllergiesController(AtchooClientContext db)
    {
      _db = db;
    }
   
    public ActionResult Index()
    {
      List<UserAllergy> model = _db.UserAllergies.ToList();
      return View(model);
    }
    public ActionResult Details(int id)
    {
      var thisAllergy = _db.UserAllergies
        .Include(userAllergy => userAllergy.JoinEntities)
        .ThenInclude(join => join.userProfile)
        .FirstOrDefault(userAllergy => userAllergy.UserAllergyId == id);
      return View(thisAllergy);
    }
  }
}