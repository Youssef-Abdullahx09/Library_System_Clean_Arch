using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.Reflection;

namespace Infrastructure.Persistence.Configurations;

public class AppPermissionConfiguration : IEntityTypeConfiguration<AppPermission>
{
    public void Configure(EntityTypeBuilder<AppPermission> builder)
    {
        var permissions = Enum.GetValues<PermissionOptions>()
            .Select(option => new AppPermission
            {
                Id = (int)option,
                Name = option.ToString(),
                NameAr = option.GetType().GetField(option.ToString())
                    .GetCustomAttributes<DescriptionAttribute>().FirstOrDefault()
                    .Description,
            })
            .ToList();

        builder
            .HasData(permissions);
    }
}
