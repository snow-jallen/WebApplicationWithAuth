using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

    public class SignUp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PartyId { get; set; }
        public Party Party { get; set; }
        public List<FoodAssignment> FoodAssignments { get; set; }
    }

    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartsOn { get; set; }
        public List<SignUp> SignUps { get; set; }
    }

    public class FoodAssignment
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string Units { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public int SignUpId { get; set; }
        public SignUp SignUp { get; set; }
    }
}
