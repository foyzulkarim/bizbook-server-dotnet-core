using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace B2BCoreApi.Models
{
    public class SecurityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<ApplicationPermission> Permissions { get; set; }
        public DbSet<ApplicationResource> Resources { get; set; }
    }
}