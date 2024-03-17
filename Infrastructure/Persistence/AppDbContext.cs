using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppProfile> AppProfiles { get; set; }
    public DbSet<AppPermission> AppPermissions { get; set; }
    public DbSet<AppFeature> AppFeatures { get; set; }
    public DbSet<AppProfilePermission> AppProfilePermissions { get; set; }
    public DbSet<AppFeaturePermission> AppFeaturePermissions { get; set; }
    public DbSet<AppUserProfile> AppUserProfiles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
