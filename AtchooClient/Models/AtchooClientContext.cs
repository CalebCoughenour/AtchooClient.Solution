using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace AtchooClient.Models
{
  public class AtchooClientContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserAllergy> UserAllergies { get; set; }
    public DbSet<ProfileAllergy> ProfileAllergies { get; set; }
    public AtchooClientContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			    base.OnModelCreating(modelBuilder);
        	modelBuilder.Entity<UserAllergy>()
            .HasData(
                new UserAllergy
                { 
                  UserAllergyId = 1, 
                  Allergy = "Lactose Intolerant"
                },
                new UserAllergy { UserAllergyId = 2, Allergy = "Pollen" },
                new UserAllergy { UserAllergyId = 3, Allergy = "Dust"},
                new UserAllergy { UserAllergyId = 4, Allergy = "Shellfish"},
                new UserAllergy { UserAllergyId = 5, Allergy = "Peanuts"},
                new UserAllergy { UserAllergyId = 6, Allergy = "Pet Fur"},
                new UserAllergy { UserAllergyId = 7, Allergy = "Perfumes"},
                new UserAllergy { UserAllergyId = 8, Allergy = "Insects"},
                new UserAllergy { UserAllergyId = 9, Allergy = "Soy"},
                new UserAllergy { UserAllergyId = 10, Allergy = "Gluten"}
            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserProfile>()
              .HasData(
                  new UserProfile
                  {
                    UserProfileId = 1,
                    Name = "John Doe",
                    DOB = 010119999,
                    Bio = "Just a dude",
                    ProfileImg = "https://ibb.co/RcdCV40"
                  }
              );
        }
  }
}