using System;
using System.Collections.Generic;
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
    public string Name { get; set; }
    public int DOB { get; set; }
    public string Bio { get; set; }
    public string ProfileImg { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<ProfileAllergy> JoinEntities { get; }
  }
}