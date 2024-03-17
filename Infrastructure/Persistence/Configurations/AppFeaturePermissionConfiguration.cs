using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AppFeaturePermissionConfiguration : IEntityTypeConfiguration<AppFeaturePermission>
{
    public void Configure(EntityTypeBuilder<AppFeaturePermission> builder)
    {
        builder
            .HasKey(x => new { x.AppFeatureId, x.AppPermissionId });


        builder
            .HasData(new List<AppFeaturePermission>
            {
                new AppFeaturePermission
                {
                    AppFeatureId = (int)FeatureOptions.Books,
                    AppPermissionId = (int)PermissionOptions.List,
                },
                new AppFeaturePermission
                {
                    AppFeatureId = (int)FeatureOptions.Books,
                    AppPermissionId = (int)PermissionOptions.Create,
                },
                new AppFeaturePermission
                {
                    AppFeatureId = (int)FeatureOptions.Books,
                    AppPermissionId = (int)PermissionOptions.Update,
                },
                new AppFeaturePermission
                {
                    AppFeatureId = (int)FeatureOptions.Books,
                    AppPermissionId = (int)PermissionOptions.Delete,
                },
            });
    }
}
