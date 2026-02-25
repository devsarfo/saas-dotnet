using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Identity;

[Table(AppSchema.Users, Schema = AppSchema.Identity)]
public class User : AuditableEntity
{
    public User()
    {
    }
    
    [MaxLength(255)] public required string Name { get; set; }

    [MaxLength(255)] public required string FirstName { get; set; }

    [MaxLength(255)] public required string LastName { get; set; }

    [MaxLength(255)] public required string Email { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    [MaxLength(255)] public string? Phone { get; set; }

    public DateTime? PhoneVerifiedAt { get; set; }

    public required string Password { get; set; }

    public bool IsActive { get; set; }
}