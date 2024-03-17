using Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorizations;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(FeatureOptions featureOptions, PermissionOptions permissionOptions)
        : base($"{featureOptions.ToString()}-{permissionOptions.ToString()}")
    {

    }
}
