using System.ComponentModel.DataAnnotations.Schema;
using SaaS.NET.Core.Common;
using SaaS.NET.Shared.Constants;

namespace SaaS.NET.Core.Entities.Tenant;

[Table(AppSchema.TenantUserRoles, Schema = AppSchema.Identity)]
public class TenantUserRole : TimestampEntity
{
    public Guid TenantUserId { get; set; }
    public TenantUser TenantUser { get; set; } = null!;

    public Guid TenantRoleId { get; set; }
    public TenantRole TenantRole { get; set; } = null!;
}