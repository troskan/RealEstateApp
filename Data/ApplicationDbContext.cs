using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Models;

namespace RealEstateApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Estate> Estate { get; set; }
        public DbSet<EstateType> EstateType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding data for EstateType
            modelBuilder.Entity<EstateType>().HasData(
                new EstateType { EstateTypeId = 1, TypeName = "Apartment" },
                new EstateType { EstateTypeId = 2, TypeName = "House" },
                new EstateType { EstateTypeId = 3, TypeName = "Cabin" }
            );

            // Seeding data for Estate
            modelBuilder.Entity<Estate>().HasData(
                new Estate { EstateId = 1, EstateTypeId = 1, Address = "123 App St.", Price = 200000, IsSold = false },
                new Estate { EstateId = 2, EstateTypeId = 2, Address = "456 House Rd.", Price = 400000, IsSold = false }
            );
        }
    }
}