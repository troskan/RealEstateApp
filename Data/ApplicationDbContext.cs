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
        public DbSet<EstateImage> EstateImage { get; set; }

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
                new Estate { EstateId = 1, EstateTypeId = 1, Address = "123 App St.", Price = 200000, IsSold = false, Description = "No description" },
                new Estate { EstateId = 2, EstateTypeId = 2, Address = "456 House Rd.", Price = 400000, IsSold = false, Description = "No description" }
            );
            // Seeding data for Estate
            modelBuilder.Entity<EstateImage>().HasData(
                new EstateImage { EstateImageId = 1, EstateId = 1, Url = "https://images.unsplash.com/photo-1515263487990-61b07816b324?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80" },
                new EstateImage { EstateImageId = 2, EstateId = 2, Url = "https://images.unsplash.com/photo-1625602812206-5ec545ca1231?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80" }
            );
        }
    }
}