using Microsoft.EntityFrameworkCore;
using ptcApi.Model;

namespace PtcApi.Model
{
  public class PtcDbContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<AppUserClaim> UserClaims { get; set; }

    // private const string CONN =
    //               @"Server=Localhost;
    //                 Database=PTC-Pluralsight;
    //                 Trusted_Connection=True;
    //                 MultipleActiveResultSets=true";

    private const string CONN = @"Server=DESKTOP-7IM2BOJ\SQL;
    Database=PTC-Pluralsight;
    Trusted_Connection=True";

    protected override void OnConfiguring(
                DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(CONN);
    }
  }
}
