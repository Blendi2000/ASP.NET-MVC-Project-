using GymWebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;

namespace GymWebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Bill> Bills { get; set; }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>().ToTable("Membership");
            modelBuilder.Entity<Bill>().ToTable("Bill");
            modelBuilder.Entity<Trainer>().ToTable("Trainer");
            modelBuilder.Entity<Schedule>().ToTable("Schedules");
            base.OnModelCreating(modelBuilder);
        }


        public async Task<int> SaveChangesAsync()
        {
            string user = httpContextAccessor.HttpContext.User.Identity.Name;
            AddTimestamps(user);
            return await base.SaveChangesAsync();


        }
        private void AddTimestamps(string owner)
        {
            foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = owner;
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = owner;
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }
        }
    }
}
