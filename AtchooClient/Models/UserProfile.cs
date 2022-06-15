using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    public string ProfileImg { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<ProfileAllergy> JoinEntities { get; }
  }
}