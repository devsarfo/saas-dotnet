using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Tenant;

[Table(AppSchema.Tenants, Schema = AppSchema.Identity)]
public class Tenant : AuditableEntity
{
    public required string Name { get; set; }

    public required string Domain { get; set; }

    public ICollection<TenantUser> TenantUsers { get; set; } = new List<TenantUser>();

    public ICollection<TenantRole> TenantRoles { get; set; } = new List<TenantRole>();

    public ICollection<TenantPermission> TenantPermissions { get; set; } = new List<TenantPermission>();
}