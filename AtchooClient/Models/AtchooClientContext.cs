using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AtchooClient.Models
{
  public class AtchooClientContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<UserProfile> UserProfiles { get; set; }
    public AtchooClientContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}