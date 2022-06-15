using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using AtchooClient.Models;

namespace AtchooClient.Controllers
{
  [Authorize]
  public class UserProfilesController : Controller
  {
    private readonly AtchooClientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserProfilesController(UserManager<ApplicationUser> userManager, AtchooClientContext db)
    {
      _userManager = userManager;
      _db = db;
    } 
  
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userProfile = _db.UserProfiles.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userProfile);
    }
    public ActionResult Create()
    {
      ViewBag.UserAllergyId = new SelectList(_db.UserAllergies, "UserAllergyId", "Allergy");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserProfile userProfile, int UserAllergyId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      userProfile.User = currentUser;
      _db.UserProfiles.Add(userProfile);
      _db.SaveChanges();
      if (UserAllergyId != 0)
      {
        _db.ProfileAllergies.Add(new ProfileAllergy() { UserAllergyId = UserAllergyId, UserProfileId = userProfile.UserProfileId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisUserProfile = _db.UserProfiles
        .Include(userProfile => userProfile.JoinEntities)
        .ThenInclude(join => join.userAllergy)
        .FirstOrDefault(userProfile => userProfile.UserProfileId == id);
      return View(thisUserProfile);
    }
    public ActionResult Edit(int id)
    {
      var thisUserProfile = _db.UserProfiles.FirstOrDefault(userprofile => userprofile.UserProfileId == id);
      ViewBag.UserAllergyId = new SelectList(_db.UserAllergies, "UserAllergyId", "Allergy");
      return View(thisUserProfile);
    }
    [HttpPost]
    public ActionResult Edit(UserProfile userprofile)
    {
      _db.Entry(userprofile).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddAllergy(int id)
    {
      var thisUserProfile = _db.UserProfiles.FirstOrDefault(userProfile => userProfile.UserProfileId == id);
      ViewBag.UserAllergyId = new SelectList(_db.UserAllergies, "UserAllergyId", "Allergy");
      return View(thisUserProfile);
    }
    [HttpPost]
    public ActionResult AddAllergy(UserProfile userprofile, int UserAllergyId)
    {
      if(UserAllergyId != 0)
      {
        _db.ProfileAllergies.Add(new ProfileAllergy() {UserAllergyId = UserAllergyId, UserProfileId = userprofile.UserProfileId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteAllergy(int joinId)
    {
      var joinEntry = _db.ProfileAllergies.FirstOrDefault(entry => entry.ProfileAllergyId == joinId);
      _db.ProfileAllergies.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisUserProfile = _db.UserProfiles.FirstOrDefault(userprofile => userprofile.UserProfileId == id);
      return View(thisUserProfile);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisUserProfile = _db.UserProfiles.FirstOrDefault(userprofile => userprofile.UserProfileId == id);
      _db.UserProfiles.Remove(thisUserProfile);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}