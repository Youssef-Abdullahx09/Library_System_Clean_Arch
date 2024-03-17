using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AppUserProfileConfiguration : IEntityTypeConfiguration<AppUserProfile>
{
    public void Configure(EntityTypeBuilder<AppUserProfile> builder)
    {
        builder
            .HasKey(x => new { x.AppUserId, x.AppProfileId });
    }
}
