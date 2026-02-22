using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Identity;

[Table(AppSchema.Users, Schema = AppSchema.Identity)]
public class User : AuditableEntity
{
    public User(string firstName, string lastName, string email, string phone, string password, bool isActive = true)
    {
        Name = $"{firstName} {lastName}".Trim();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Password = BCrypt.Net.BCrypt.HashPassword(password);
        IsActive = isActive;
    }

    public required string Name { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    public string? Phone { get; set; }

    public DateTime? PhoneVerifiedAt { get; set; }

    public required string Password { get; set; }

    public bool IsActive { get; set; }
}