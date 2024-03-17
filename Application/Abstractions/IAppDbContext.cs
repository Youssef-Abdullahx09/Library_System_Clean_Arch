using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions;

public interface IAppDbContext
{
    DbSet<AppUser> AppUsers { get; set; }
    DbSet<AppProfile> AppProfiles { get; set; }
    DbSet<AppPermission> AppPermissions { get; set; }
    DbSet<AppFeature> AppFeatures { get; set; }
    DbSet<AppProfilePermission> AppProfilePermissions { get; set; }
    DbSet<AppFeaturePermission> AppFeaturePermissions { get; set; }
    DbSet<AppUserProfile> AppUserProfiles { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
