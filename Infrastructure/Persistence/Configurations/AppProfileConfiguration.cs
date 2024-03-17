using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.Reflection;

namespace Infrastructure.Persistence.Configurations;

public class AppProfileConfiguration : IEntityTypeConfiguration<AppProfile>
{
    public void Configure(EntityTypeBuilder<AppProfile> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasMany(x => x.AppFeaturePermissions)
            .WithMany(x => x.AppProfiles)
            .UsingEntity<AppProfilePermission>();

        var profiles = Enum.GetValues<ProfileOptions>()
            .Select(option => new AppProfile
            {
                Id = (int)option,
                Name = option.ToString(),
                NameAr = option.GetType().GetField(option.ToString())
                    .GetCustomAttributes<DescriptionAttribute>().FirstOrDefault()
                    .Description,
            })
            .ToList();

        builder
            .HasData(profiles);
    }
}
