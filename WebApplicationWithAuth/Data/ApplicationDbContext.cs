using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace WebApplicationWithAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<FoodAssignment> FoodAssignments { get; set; }
    }
}
