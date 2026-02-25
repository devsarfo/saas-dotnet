using SaaS.NET.Infrastructure.Persistence;
using SaaS.NET.Infrastructure.Seeders.Identity;
using SaaS.NET.Infrastructure.Seeders.Tenant;

namespace SaaS.NET.Infrastructure.Seeders;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public DatabaseSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Run()
    {
        var seeders = new List<IDatabaseSeeder>
        {
            // Identity 
            new PermissionSeeder(_dbContext),
            new UserSeeder(_dbContext),

            // Tenant
            new TenantSeeder(_dbContext),
            new TenantRoleSeeder(_dbContext),
            new TenantRolePermissionSeeder(_dbContext),
            new TenantUserSeeder(_dbContext),
        };

        foreach (var seeder in seeders)
        {
            await seeder.Run();
        }
    }
}