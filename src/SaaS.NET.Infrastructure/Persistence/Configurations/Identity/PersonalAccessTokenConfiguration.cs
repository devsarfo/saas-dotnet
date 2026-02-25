using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        var comparer = new ValueComparer<Dictionary<string, object>?>(
            (c1, c2) => JsonHelper.CompareDictionaries(c1, c2),
            c => JsonHelper.GetDictionaryHashCode(c),
            c => JsonHelper.CloneDictionary(c)
        );

        builder.Property(p => p.Abilities)
            .HasConversion(converter)
            .HasColumnType("jsonb")
            .Metadata.SetValueComparer(comparer);

        builder.HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}