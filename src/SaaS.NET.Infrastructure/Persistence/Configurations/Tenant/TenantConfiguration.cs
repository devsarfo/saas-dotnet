using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaS.NET.Core.Entities.Tenant;

namespace SaaS.NET.Infrastructure.Persistence.Configurations.Tenant;

public class TenantConfiguration : IEntityTypeConfiguration<Core.Entities.Tenant.Tenant>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Tenant.Tenant> builder)
    {
        builder.HasIndex(t => t.Domain).IsUnique();

        builder.HasMany<TenantUser>()
            .WithOne(tu => tu.Tenant)
            .HasForeignKey(tu => tu.TenantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<TenantRole>()
            .WithOne(tr => tr.Tenant)
            .HasForeignKey(tr => tr.TenantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<TenantPermission>()
            .WithOne(tp => tp.Tenant)
            .HasForeignKey(tp => tp.TenantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}