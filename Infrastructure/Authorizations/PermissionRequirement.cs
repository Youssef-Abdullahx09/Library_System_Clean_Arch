using Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorizations;

public class PermissionRequirement
    : IAuthorizationRequirement
{
    public PermissionRequirement(FeatureOptions feature,
        PermissionOptions permission)
    {
        Feature = feature;
        Permission = permission;
    }

    public FeatureOptions Feature { get; set; }
    public PermissionOptions Permission { get; set; }
}
