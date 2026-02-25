using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Core.Entities.Tenant;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Identity;

[Table(AppSchema.Permissions, Schema = AppSchema.Identity)]
public class Permission : AuditableEntity
{
    [MaxLength(255)]
    public required string Name { get; set; }
    
    [MaxLength(255)]
    public required string Slug { get; set; }
    
    public string? Description { get; set; }

    public ICollection<TenantRolePermission> TenantRolePermissions { get; set; } = new List<TenantRolePermission>();
}