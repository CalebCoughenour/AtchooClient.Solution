using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AtchooClient.Models
{
  public class UserAllergy
  {
    public UserAllergy()
    {
      this.JoinEntities = new HashSet<ProfileAllergy>();
    }
    public int UserAllergyId { get; set; }
    public string Allergy { get; set; }
    
    public virtual ICollection<ProfileAllergy> JoinEntities { get; set; }    
  }
}