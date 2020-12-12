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
        public DbSet<Role> Roles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Local> Locations { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Image> Images
        {
            get; set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InnerCategory>()
                .HasMany(c => c.Advertisements)
                .WithOne(e => e.InnerCategory)
                .HasForeignKey(e => e.InnerCategoryId);

            modelBuilder.Entity<Category>().Property(x => x.Title).IsRequired();

            modelBuilder.Entity<Local>()
                .HasMany(c => c.Advertisements)
                .WithOne(e => e.Local)
                .HasForeignKey(e => e.LocalId)
                .IsRequired();

            modelBuilder.Entity<Advertisement>()
                .HasMany(c => c.Images)
                .WithOne(e => e.Advertisment)
                .HasForeignKey(e => e.AdvertismentId);

            modelBuilder.Entity<UserRole>()
                .HasKey(bc => new { bc.UserId, bc.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(bc => bc.RoleId);
        }

    }
}
