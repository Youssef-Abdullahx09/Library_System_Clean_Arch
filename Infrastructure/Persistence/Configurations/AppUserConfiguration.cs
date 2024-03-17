using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasMany(x => x.AppProfiles)
            .WithMany(x => x.AppUsers)
            .UsingEntity<AppUserProfile>();
    }
}
