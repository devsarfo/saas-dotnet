using Microsoft.EntityFrameworkCore;
using SaaS.NET.Core.Entities.Tenant;
using SaaS.NET.Infrastructure.Persistence;
using SaaS.NET.Shared.Constants;
using SaaS.NET.Shared.Extensions;

namespace SaaS.NET.Infrastructure.Seeders.Tenant;

public class TenantRoleSeeder : IDatabaseSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public TenantRoleSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Run()
    {
        var tenant = await _dbContext.Tenants.OrderBy(t => t.CreatedAt).FirstOrDefaultAsync();
        if (tenant is null) return;

        var tenantRoles = new List<TenantRole>
        {
            new()
            {
                TenantId = tenant.Id,
                Name = AppConstants.Admin.CapitaliseFirst(),
                Slug = AppConstants.Admin,
                IsActive = true
            },
            new()
            {
                TenantId = tenant.Id,
                Name = AppConstants.User.CapitaliseFirst(),
                Slug = AppConstants.User,
                IsActive = true
            }
        };

        var newRoles = tenantRoles
            .Where(tr => !_dbContext.TenantRoles.Any(r => r.Slug == tr.Slug))
            .ToList();

        if (newRoles.Count != 0)
        {
            await _dbContext.TenantRoles.AddRangeAsync(newRoles);
            await _dbContext.SaveChangesAsync();
        }
    }
}