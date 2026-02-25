using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Core.Entities.Identity;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Tenant;

[Table(AppSchema.TenantRolePermissions, Schema = AppSchema.Identity)]
public class TenantRolePermission: TimestampEntity
{
    public required Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;
    
    public Guid TenantRoleId { get; set; }
    public TenantRole TenantRole { get; set; } = null!;

    public Guid PermissionId { get; set; }
    public Permission Permission { get; set; } = null!;
}