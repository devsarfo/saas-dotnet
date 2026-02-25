using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Core.Entities.Identity;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Tenant;

[Table(AppSchema.Tenants, Schema = AppSchema.Identity)]
public class Tenant : AuditableEntity
{
    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(255)]
    public required string Domain { get; set; }

    public ICollection<TenantUser> TenantUsers { get; set; } = new List<TenantUser>();

    public ICollection<TenantRole> TenantRoles { get; set; } = new List<TenantRole>();

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}