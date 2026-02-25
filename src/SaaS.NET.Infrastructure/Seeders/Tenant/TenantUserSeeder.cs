using Microsoft.EntityFrameworkCore;
using SaaS.NET.Core.Entities.Tenant;
using SaaS.NET.Infrastructure.Persistence;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Infrastructure.Seeders.Tenant;

public class TenantUserSeeder : IDatabaseSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public TenantUserSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task Run()
    {
        var defaultTenant = await _dbContext.Tenants.FirstOrDefaultAsync(u =>
            u.Name == AppConstants.DefaultName && u.Domain == AppConstants.DefaultDomain);
        if (defaultTenant is null) return;

        var defaultUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == AppConstants.DefaultEmail);
        if (defaultUser is null) return;

        var defaultRole = await _dbContext.TenantRoles.FirstOrDefaultAsync(tr =>
            tr.TenantId == defaultTenant.Id && tr.Slug == AppConstants.Admin);
        if (defaultRole is null) return;

        var exists =
            await _dbContext.TenantUsers.AnyAsync(tu => tu.TenantId == defaultTenant.Id && tu.UserId == defaultUser.Id);
        if (exists) return;

        var tenantUser = new TenantUser
        {
            TenantId = defaultTenant.Id,
            UserId = defaultUser.Id
        };

        _dbContext.TenantUsers.Add(tenantUser);

        _dbContext.TenantUserRoles.Add(new TenantUserRole
        {
            TenantId = defaultTenant.Id,
            TenantUserId = tenantUser.Id,
            TenantRoleId = defaultRole.Id,
        });

        await _dbContext.SaveChangesAsync();
    }
}