using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MRWorld.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { set; get; }
        public DbSet<Users> Users { set; get; }
        public DbSet<MemberShip> MemberShips { set; get; }
        public DbSet<AddMovie> AddingData { set; get; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}