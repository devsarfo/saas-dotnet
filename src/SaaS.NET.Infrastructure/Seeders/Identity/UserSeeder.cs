using Microsoft.EntityFrameworkCore;
using SaaS.NET.Core.Entities.Identity;
using SaaS.NET.Infrastructure.Persistence;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Infrastructure.Seeders.Identity;

public class UserSeeder : IDatabaseSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public UserSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Run()
    {
        var users = new List<User>
        {
            new()
            {
                Name = AppConstants.DefaultName,
                FirstName = AppConstants.DefaultFirstName,
                LastName = AppConstants.DefaultLastName,
                Email = AppConstants.DefaultEmail,
                Password = BCrypt.Net.BCrypt.HashPassword(AppConstants.DefaultPassword),
            }
        };

        foreach (var user in users)
        {
            var exists = await _dbContext.Users.AnyAsync(u => u.Email == user.Email || u.Phone == user.Phone);
            if (exists) continue;

            _dbContext.Users.Add(user);
        }

        await _dbContext.SaveChangesAsync();
    }
}