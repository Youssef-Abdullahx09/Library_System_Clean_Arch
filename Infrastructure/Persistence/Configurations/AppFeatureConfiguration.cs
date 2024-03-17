using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.Reflection;

namespace Infrastructure.Persistence.Configurations;

public class AppFeatureConfiguration : IEntityTypeConfiguration<AppFeature>
{
    public void Configure(EntityTypeBuilder<AppFeature> builder)
    {
        builder
            .HasMany(x => x.AppPermissions)
            .WithMany(x => x.AppFeatures)
            .UsingEntity<AppFeaturePermission>();

        var features = Enum.GetValues<FeatureOptions>()
            .Select(option => new AppFeature
            {
                Id = (int)option,
                Name = option.ToString(),
                NameAr = option.GetType().GetField(option.ToString())
                    .GetCustomAttributes<DescriptionAttribute>().FirstOrDefault()
                    .Description,
            })
            .ToList();

        builder
            .HasData(features);
    }
}
