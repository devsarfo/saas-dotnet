using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Tenant;

[Table(AppSchema.TenantRolePermissions, Schema = AppSchema.Identity)]
public class TenantRolePermission: TimestampEntity
{
    public Guid TenantRoleId { get; set; }
    public TenantRole TenantRole { get; set; } = null!;

    public Guid TenantPermissionId { get; set; }
    public TenantPermission TenantPermission { get; set; } = null!;
}