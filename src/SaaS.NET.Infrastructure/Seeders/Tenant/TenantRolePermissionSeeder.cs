using Microsoft.EntityFrameworkCore;
using SaaS.NET.Core.Entities.Tenant;
using SaaS.NET.Infrastructure.Persistence;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Infrastructure.Seeders.Tenant;

public class TenantRolePermissionSeeder : IDatabaseSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public TenantRolePermissionSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Run()
    {
        var admin = await _dbContext.TenantRoles.FirstOrDefaultAsync(r => r.Slug == AppConstants.Admin);
        if (admin is null) return;

        var permissions = await _dbContext.Permissions.ToListAsync();
        if (permissions.Count == 0) return;

        foreach (var permission in permissions)
        {
            var exists = await _dbContext.TenantRolePermissions.AnyAsync(trp =>
                trp.TenantRoleId == admin.Id && trp.PermissionId == permission.Id);

            if (!exists)
            {
                _dbContext.TenantRolePermissions.Add(new TenantRolePermission
                {
                    TenantId = admin.TenantId,
                    TenantRoleId = admin.Id,
                    PermissionId = permission.Id
                });
            }
        }

        await _dbContext.SaveChangesAsync();
    }
}