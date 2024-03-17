using Application.Abstractions;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Authorizations;

public class PermissionService
    : IPermissionService
{
    private readonly IAppDbContext _context;

    public PermissionService(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<HashSet<FeaturePermission>> GetPermissionAsync(int currentProfileId)
    {
        var featurePermissions = await _context.AppFeaturePermissions.Where(x => x.AppProfiles.Any(profile =>
                profile.Id == currentProfileId))
            .Select(x => new FeaturePermission
            {
                Feature = (FeatureOptions)x.AppFeatureId,
                Permission = (PermissionOptions)x.AppPermissionId
            })
            .ToListAsync();

        return featurePermissions
            .ToHashSet();
    }
}
