using Microsoft.AspNet.Identity.EntityFramework;
using ShipsService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShipsService.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Ship> Ships { get; set; }
        //public DbSet<ErrorMessage> ErrorMessages { get; set; }

        public DbSet<Document> Documents { get; set; }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasMany(c => c.ShipsDocuments);
            modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Avatar);
            
            modelBuilder.Entity<Ship>().HasMany(c => c.ShipsDocuments);

            // modelBuilder.Entity<MathTask>().HasMany(c => c.Documents);
            // modelBuilder.Entity<MathTaskSolution>().HasMany(c => c.Documents);
        }
    }
}