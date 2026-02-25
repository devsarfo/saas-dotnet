using Microsoft.EntityFrameworkCore;
using SaaS.NET.Infrastructure.Persistence;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Infrastructure.Seeders.Tenant;

public class TenantSeeder : IDatabaseSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public TenantSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task Run()
    {
        var tenants = new List<Core.Entities.Tenant.Tenant>
        {
            new()
            {
                Name = AppConstants.DefaultName,
                Domain = AppConstants.DefaultDomain
            }
        };

        foreach (var tenant in tenants)
        {
            var exists = await _dbContext.Tenants.AnyAsync(t => t.Domain == tenant.Domain && t.Name == tenant.Name);
            if (exists) continue;

            _dbContext.Tenants.Add(tenant);
        }

        await _dbContext.SaveChangesAsync();
    }
}