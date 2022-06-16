using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtchooClient.Models
{
  public class UserProfile
  {
    public UserProfile()
    {
      this.JoinEntities = new HashSet<ProfileAllergy>();
    }
    
    public int UserProfileId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string DOB { get; set; }
    [Required]
    public string Bio { get; set; }
     [NotMapped]
    public IFormFile FrontImage { get; set;}
    public string ImageUrl { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<ProfileAllergy> JoinEntities { get; }
  }
}