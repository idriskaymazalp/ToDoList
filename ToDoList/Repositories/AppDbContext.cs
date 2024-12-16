using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using System.Reflection.Metadata;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Duty> Duties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Duty>()
                .HasKey(x => x.DutyId);
            modelBuilder.Entity<Duty>()
                .Property(x => x.DutyId).UseIdentityColumn();
            modelBuilder.Entity<Duty>()
                .Property(x=>x.DutyNote).IsRequired().HasMaxLength(50);
                     
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
