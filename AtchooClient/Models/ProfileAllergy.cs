namespace AtchooClient.Models
{
  public class ProfileAllergy
  {
    public int ProfileAllergyId { get; set; }
    public int UserProfileId { get; set; }
    public int UserAllergyId { get; set;}
    public virtual UserProfile userProfile { get; set; }
    public virtual UserAllergy userAllergy { get; set; }
  } 
} 