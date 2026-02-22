using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaS.NET.Core.Entities.Tenant;

namespace SaaS.NET.Infrastructure.Persistence.Configurations.Tenant;

public class TenantRolePermissionConfiguration : IEntityTypeConfiguration<TenantRolePermission>
{
    public void Configure(EntityTypeBuilder<TenantRolePermission> builder)
    {
        builder.HasKey(trp => new { trp.TenantRoleId, trp.TenantPermissionId, trp.DeletedAt });

        builder.HasOne(trp => trp.TenantRole)
            .WithMany(tr => tr.TenantRolePermissions)
            .HasForeignKey(trp => trp.TenantRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(trp => trp.TenantPermission)
            .WithMany(tp => tp.TenantRolePermissions)
            .HasForeignKey(trp => trp.TenantPermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}