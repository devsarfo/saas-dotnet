using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Tenant;

[Table(AppSchema.TenantPermissions, Schema = AppSchema.Identity)]
public class TenantPermission : AuditableEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;
    
    public required string Name { get; set; }
    
    public required string Slug { get; set; }
    
    public string? Description { get; set; }

    public ICollection<TenantRolePermission> TenantRolePermissions { get; set; } = new List<TenantRolePermission>();
}