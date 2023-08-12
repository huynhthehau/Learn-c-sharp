using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace User.Management.API.DataContext
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRole(builder);
        }
        private void SeedRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name="Admin", ConcurrencyStamp="1", NormalizedName="Admin"},
                new IdentityRole() { Name="User", ConcurrencyStamp="2", NormalizedName= "User" },
                new IdentityRole() { Name="HR", ConcurrencyStamp="3", NormalizedName= "HR" }
                );
        }
    }
}
