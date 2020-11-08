using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<InnerCategory> InnerCategories { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Local> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InnerCategory>()
                .HasMany(c => c.Advertisements)
                .WithOne(e => e.InnerCategory)
                .HasForeignKey(e => e.InnerCategoryId);

            modelBuilder.Entity<Local>()
                .HasMany(c => c.Advertisements)
                .WithOne(e => e.Local)
                .HasForeignKey(e => e.LocalId);
        }

    }
}
