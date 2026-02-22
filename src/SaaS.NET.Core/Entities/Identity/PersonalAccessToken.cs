using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Identity;

[Table(AppSchema.PersonalAccessTokens, Schema = AppSchema.Identity)]
public class PersonalAccessToken : Entity
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(255)] 
    public required string Token { get; set; }

    public Dictionary<string, object>? Abilities { get; set; }

    public DateTime? LastUsedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }
}