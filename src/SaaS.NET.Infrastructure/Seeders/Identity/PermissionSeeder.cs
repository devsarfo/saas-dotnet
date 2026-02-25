using Microsoft.EntityFrameworkCore;
using SaaS.NET.Core.Entities.Identity;
using SaaS.NET.Infrastructure.Persistence;
using SaaS.NET.Shared.Constants;
using SaaS.NET.Shared.Extensions;

namespace SaaS.NET.Infrastructure.Seeders.Identity;

public class PermissionSeeder : IDatabaseSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public PermissionSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Run()
    {
        var modules = new[]
        {
            AppConstants.User,
            AppConstants.Permission,
            AppConstants.Tenant,
            AppConstants.TenantUser,
            AppConstants.TenantRole,
            AppConstants.TenantRolePermission
        };

        var permissions = new List<Permission>();

        foreach (var module in modules)
        {
            var name = module.Replace("_", " ").ToTitleCase();
            var slug = module.ToSnakeCase();

            permissions.Add(new Permission { Name = name, Slug = slug });

            var actions = new[] { AppConstants.Create, AppConstants.Update, AppConstants.Delete };
            permissions.AddRange(actions.Select(action => new Permission
            {
                Name = $"{action} {name}".ToTitleCase(),
                Slug = $"{slug}_{action.ToSnakeCase()}"
            }));
        }

        foreach (var permission in permissions)
        {
            var exists = await _dbContext.Permissions.AnyAsync(a => a.Slug == permission.Slug);
            if (!exists)
            {
                _dbContext.Permissions.Add(permission);
            }
        }

        await _dbContext.SaveChangesAsync();
    }
}