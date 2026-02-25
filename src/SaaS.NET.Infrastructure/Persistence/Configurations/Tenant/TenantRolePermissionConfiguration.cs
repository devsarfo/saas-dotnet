using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaS.NET.Core.Entities.Tenant;

namespace SaaS.NET.Infrastructure.Persistence.Configurations.Tenant;

public class TenantRolePermissionConfiguration : IEntityTypeConfiguration<TenantRolePermission>
{
    public void Configure(EntityTypeBuilder<TenantRolePermission> builder)
    {
        builder.HasKey(trp => new { trp.TenantId, trp.TenantRoleId, trp.PermissionId });
        builder.HasIndex(trp => new { trp.TenantId, trp.TenantRoleId, trp.PermissionId, trp.DeletedAt });

        builder.HasOne(trp => trp.TenantRole)
            .WithMany(tr => tr.TenantRolePermissions)
            .HasForeignKey(trp => trp.TenantRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(trp => trp.Permission)
            .WithMany(tp => tp.TenantRolePermissions)
            .HasForeignKey(trp => trp.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}