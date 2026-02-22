using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Identity;

[Table(AppSchema.Sessions, Schema = AppSchema.Identity)]
public class Session : Entity
{
    public Guid? UserId { get; set; }

    public User? User { get; set; }

    [MaxLength(45)]
    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public DateTime LastActivity { get; set; }
}