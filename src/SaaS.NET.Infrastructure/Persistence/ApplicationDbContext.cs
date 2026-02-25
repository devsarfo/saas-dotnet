using Microsoft.EntityFrameworkCore;
using SaaS.NET.Core.Entities.Identity;
using SaaS.NET.Core.Entities.Tenant;
using SaaS.NET.Infrastructure.Persistence.Configurations.Identity;
using SaaS.NET.Infrastructure.Persistence.Configurations.Tenant;

namespace SaaS.NET.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Identity
    public DbSet<User> Users => Set<User>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<PersonalAccessToken> PersonalAccessTokens => Set<PersonalAccessToken>();
    public DbSet<Permission> Permissions { get; set; }

    // Tenant
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantUser> TenantUsers { get; set; }
    public DbSet<TenantRole> TenantRoles { get; set; }
    public DbSet<TenantRolePermission> TenantRolePermissions { get; set; }
    public DbSet<TenantUserRole> TenantUserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Identity Configurations
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new PersonalAccessTokenConfiguration());

        // Tenant Configurations
        modelBuilder.ApplyConfiguration(new TenantConfiguration());
        modelBuilder.ApplyConfiguration(new TenantUserConfiguration());
        modelBuilder.ApplyConfiguration(new TenantRoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        modelBuilder.ApplyConfiguration(new TenantRolePermissionConfiguration());
        modelBuilder.ApplyConfiguration(new TenantUserRoleConfiguration());
    }
}