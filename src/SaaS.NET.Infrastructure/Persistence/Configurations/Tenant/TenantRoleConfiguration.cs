using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaS.NET.Core.Entities.Tenant;

namespace SaaS.NET.Infrastructure.Persistence.Configurations.Tenant;

public class TenantRoleConfiguration : IEntityTypeConfiguration<TenantRole>
{
    public void Configure(EntityTypeBuilder<TenantRole> builder)
    {
        builder.HasIndex(tr => new { tr.Slug, tr.DeletedAt }).IsUnique();

        builder.HasOne(tr => tr.Tenant)
            .WithMany(t => t.TenantRoles)
            .HasForeignKey(tr => tr.TenantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(tr => tr.TenantRolePermissions)
            .WithOne(trp => trp.TenantRole)
            .HasForeignKey(trp => trp.TenantRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(tr => tr.TenantUserRoles)
            .WithOne(tur => tur.TenantRole)
            .HasForeignKey(tur => tur.TenantRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}