using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Authorizations;

public class PermissionAuthorizationHandler
    : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var currentProfileId = context.User.Claims.Where(claim =>
            claim.Type == "CurrentProfile")
            .Select(claim => Convert.ToInt32((ProfileOptions)Enum.Parse(typeof(ProfileOptions), claim.Value)))
            .FirstOrDefault();

        using IServiceScope serviceScope = _serviceScopeFactory.CreateScope();

        var permissionService = serviceScope.ServiceProvider
            .GetRequiredService<IPermissionService>();

        var currentFeaturePermissions = await permissionService.GetPermissionAsync(currentProfileId);

        if (currentFeaturePermissions.Any(featurePermission => featurePermission.Feature == requirement.Feature && featurePermission.Permission == requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}
