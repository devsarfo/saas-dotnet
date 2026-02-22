using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaS.NET.Core.Entities.Tenant;

namespace SaaS.NET.Infrastructure.Persistence.Configurations.Tenant;

public class TenantUserRoleConfiguration : IEntityTypeConfiguration<TenantUserRole>
{
    public void Configure(EntityTypeBuilder<TenantUserRole> builder)
    {
        builder.HasKey(tur => new { tur.TenantUserId, tur.TenantRoleId, tur.DeletedAt });

        builder.HasOne(tur => tur.TenantUser)
            .WithMany(tu => tu.TenantUserRoles)
            .HasForeignKey(tur => tur.TenantUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(tur => tur.TenantRole)
            .WithMany(tr => tr.TenantUserRoles)
            .HasForeignKey(tur => tur.TenantRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}