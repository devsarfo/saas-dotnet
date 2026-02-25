using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaS.NET.Core.Entities.Identity;

namespace SaaS.NET.Infrastructure.Persistence.Configurations.Identity;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasIndex(tp => new { tp.Slug }).IsUnique();

        builder.HasMany(tp => tp.TenantRolePermissions)
            .WithOne(trp => trp.Permission)
            .HasForeignKey(trp => trp.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}