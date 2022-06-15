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
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserProfile userprofile)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      userprofile.User = currentUser;
      _db.UserProfiles.Add(userprofile);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisUserProfile = _db.UserProfiles
        .Include(userprofile => userprofile.JoinEntities)
        .ThenInclude(join => join.userAllergy)
        .FirstOrDefault(userprofile => userprofile.UserProfileId == id);
      return View(thisUserProfile);
    }
    public ActionResult Edit(int id)
    {
      var thisUserProfile = _db.UserProfiles.FirstOrDefault(userprofile => userprofile.UserProfileId == id);
      ViewBag.UserAllergyId = new SelectList(_db.UserAllergies, "UserAllergyId", "Name");
      return View(thisUserProfile);
    }
    [HttpPost]
    public ActionResult Edit(UserProfile userprofile)
    {
      _db.Entry(userprofile).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddUserAllergy(int id)
    {
      var thisUserProfile = _db.UserProfiles.FirstOrDefault(userprofile => userprofile.UserProfileId == id);
      ViewBag.UserAllergyId = new SelectList(_db.UserAllergies, "UserAllergyId", "Name");
      return View(thisUserProfile);
    }
    [HttpPost]
    public ActionResult AddUserAllergy(UserProfile userprofile, int UserAllergyId)
    {
      if(UserAllergyId != 0)
      {
        _db.ProfileAllergies.Add(new ProfileAllergy() {UserAllergyId = UserAllergyId, UserProfileId = userprofile.UserProfileId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteUserAllergy(int joinId)
    {
      var joinEntry = _db.ProfileAllergies.FirstOrDefault(entry => entry.ProfileAllergyId == joinId);
      _db.ProfileAllergies.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}