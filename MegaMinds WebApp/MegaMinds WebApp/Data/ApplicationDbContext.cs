using MegaMinds_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaMinds_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<StateModel> States { get; set; }
        public DbSet<CityModel> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map models to database tables
            modelBuilder.Entity<UserModel>().ToTable("tblUserRegistration");
            modelBuilder.Entity<StateModel>().ToTable("tblState");
            modelBuilder.Entity<CityModel>().ToTable("tblCity");
        }
    }
}
