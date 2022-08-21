using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ADPortsTask.Data.Models;
using System.Linq;


namespace ADPortsTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }
        public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //necessary call of the base method
            base.OnModelCreating(modelBuilder);

             

            //setting default date autofill for all modification dates
            foreach (var entity in modelBuilder.Model.GetEntityTypes()
                .Where(et => et.FindProperty("CreatedTime") != null && et.FindProperty("UpdatedTime") != null)
                .Select(et => modelBuilder.Entity(et.ClrType)))
            {
                entity.Property("CreatedTime").HasDefaultValueSql("getdate()");
                entity.Property("UpdatedTime").HasDefaultValueSql("getdate()");
            }

            var userEntity = modelBuilder.Entity<ApplicationUser>();
            userEntity.Property("IsBlocked").HasDefaultValue(false);

            //setting default active state for all applicable entities
            foreach (var entity in modelBuilder.Model.GetEntityTypes()
                .Where(et => et.FindProperty("IsActive") != null)
                .Select(et => modelBuilder.Entity(et.ClrType)))
            {
                entity.Property("IsActive").HasDefaultValue(true);
            }
        }
    }
}
