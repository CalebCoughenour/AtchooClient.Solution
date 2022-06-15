using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AtchooClient.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtchooClient.Controllers
{
  [Authorize]
  public class UserAllergiesController : Controller
  {
    private readonly AtchooClientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserAllergiesController(UserManager<ApplicationUser> userManager, AtchooClientContext db)
    {
      _userManager = userManager;
      _db = db;
    }
   
    [AllowAnonymous]
    public ActionResult Index()
    {
      List<UserAllergy> model = _db.UserAllergies.ToList();
      ViewBag.UserProfiles = _db.UserProfiles.ToList();
      ViewBag.ProfileAllergies = _db.ProfileAllergies.ToList();
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

    public ActionResult Create()
    {
      ViewBag.UserAllergyId = new SelectList(_db.UserAllergies, "UserAllergyId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(UserAllergy userAllergy)
    {
      bool exists = _db.UserAllergies.Any(a => a.Allergy.ToUpper() == userAllergy.Allergy.ToUpper());
      if(!exists)
      {
        _db.UserAllergies.Add(userAllergy);
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisAllergy = _db.UserAllergies.FirstOrDefault(userAllergy => userAllergy.UserAllergyId == id);
      return View(thisAllergy);
    }

    [HttpPost]
    public ActionResult Edit(UserAllergy userAllergy)
    {
      _db.Entry(userAllergy).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisAllergy = _db.UserAllergies.FirstOrDefault(userAllergy => userAllergy.UserAllergyId == id);
      return View(thisAllergy);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisAllergy = _db.UserAllergies.FirstOrDefault(userAllergy => userAllergy.UserAllergyId == id);
      _db.UserAllergies.Remove(thisAllergy);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}