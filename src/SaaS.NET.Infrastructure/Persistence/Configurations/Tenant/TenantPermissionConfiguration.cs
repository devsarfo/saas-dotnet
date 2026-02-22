using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaS.NET.Core.Entities.Tenant;

namespace SaaS.NET.Infrastructure.Persistence.Configurations.Tenant;

public class TenantPermissionConfiguration : IEntityTypeConfiguration<TenantPermission>
{
    public void Configure(EntityTypeBuilder<TenantPermission> builder)
    {
        builder.HasIndex(tp => new { tp.TenantId, tp.Slug });

        builder.HasOne(tp => tp.Tenant)
            .WithMany(t => t.TenantPermissions)
            .HasForeignKey(tp => tp.TenantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(tp => tp.TenantRolePermissions)
            .WithOne(trp => trp.TenantPermission)
            .HasForeignKey(trp => trp.TenantPermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}