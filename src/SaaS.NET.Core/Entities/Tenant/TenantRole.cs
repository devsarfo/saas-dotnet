using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Tenant;

[Table(AppSchema.TenantRoles, Schema = AppSchema.Identity)]
public class TenantRole : AuditableEntity
{
    public required Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    [MaxLength(255)]
    public required string Name { get; set; }
    
    [MaxLength(255)]
    public required string Slug { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }

    public ICollection<TenantRolePermission> TenantRolePermissions { get; set; } = new List<TenantRolePermission>();
    
    public ICollection<TenantUserRole> TenantUserRoles { get; set; } = new List<TenantUserRole>();
}