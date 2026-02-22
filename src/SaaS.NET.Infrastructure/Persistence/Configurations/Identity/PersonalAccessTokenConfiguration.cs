using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaaS.NET.Core.Entities.Identity;
using SaaS.NET.Shared.Utils;

namespace SaaS.NET.Infrastructure.Persistence.Configurations.Identity;

public class PersonalAccessTokenConfiguration : IEntityTypeConfiguration<PersonalAccessToken>
{
    public void Configure(EntityTypeBuilder<PersonalAccessToken> builder)
    {
        builder.HasIndex(p => p.UserId);

        builder.HasIndex(p => p.Token).IsUnique();

        var converter = new ValueConverter<Dictionary<string, object>?, string?>(
            v => JsonHelper.SerializeDictionary(v),
            v => JsonHelper.DeserializeDictionary(v)
        );

        builder.Property(p => p.Abilities)
            .HasConversion(converter)
            .HasColumnType("text");

        builder.HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}