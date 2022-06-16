using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using AtchooClient.Models;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using AtchooClient.ViewModels;
using System;


namespace AtchooClient.Controllers
{
  [Authorize]
  public class UserProfilesController : Controller
  {
    private readonly AtchooClientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment webHostEnvironment;

    public UserProfilesController(UserManager<ApplicationUser> userManager, AtchooClientContext db,IWebHostEnvironment webHost)
    {
      _userManager = userManager;
      _db = db;
      webHostEnvironment =webHost;
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
     public string UploadFile(UserProfile userProfile)
    {
      string uniqueFilName = null;
      if(userProfile.FrontImage!=null)
      {
        string uploadFolder =Path.Combine(webHostEnvironment.WebRootPath,"img");
        uniqueFilName = Guid.NewGuid().ToString()+"_"+ userProfile.FrontImage.FileName;
        string filePath =Path.Combine(uploadFolder,uniqueFilName);
        using(var fileStream = new FileStream(filePath,FileMode.Create))
        {
          userProfile.FrontImage.CopyTo(fileStream);
        }
      }
      return uniqueFilName;
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserProfile userProfile, int UserAllergyId)
    {
      // string fileName =Path.GetFileNameWithoutExtension(userProfile.ImageFile.FileName);
      // string extension =Path.GetExtension(userProfile.ImageFile.FileName);
      // fileName = fileName + extension;
      // userProfile.ProfileImg ="~/wwwroot/img/" + fileName;
      // fileName =Path.Combine(Server.MapPath("~/wwwroot/img/"),fileName);
      // userProfile.ImageFile.SaveAs(fileName);
     
      
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      userProfile.User = currentUser;
       string uniqueFilName =UploadFile(userProfile);
      userProfile.ImageUrl =uniqueFilName;
      _db.Attach(userProfile);
      

      _db.UserProfiles.Add(userProfile);
      _db.SaveChanges();
      if (UserAllergyId != 0)
      {
        _db.ProfileAllergies.Add(new ProfileAllergy() { UserAllergyId = UserAllergyId, UserProfileId = userProfile.UserProfileId });
      }
      _db.SaveChanges();
      ModelState.Clear();
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
      string uniqueFilName =UploadFile(userprofile);
      userprofile.ImageUrl =uniqueFilName;
      //  _db.Attach(userprofile);
      // _db.Attach(userprofile);
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
      bool exists = _db.ProfileAllergies.Where(p => p.UserProfileId == userprofile.UserProfileId).Any(a => a.UserAllergyId == UserAllergyId);
      if(UserAllergyId != 0 && !exists)
      {
        _db.ProfileAllergies.Add(new ProfileAllergy() {UserAllergyId = UserAllergyId, UserProfileId = userprofile.UserProfileId});
        _db.SaveChanges();
      }
      else
      {
        return RedirectToAction("ThankYou");
      }
      return RedirectToAction("Details", new {id = userprofile.UserProfileId});
    }
    public ActionResult ThankYou()
    {
      TempData["alertMessage"] = "<script>alert('You've Already added this Allergy');</script>";
      return View();
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