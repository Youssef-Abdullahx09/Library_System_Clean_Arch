using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authorizations;

public class PermissionPolicyProvider
    : DefaultAuthorizationPolicyProvider
{
    public PermissionPolicyProvider(
        IOptions<AuthorizationOptions> options)
        : base(options)
    {
    }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy is not null)
        {
            return policy;
        }

        var policySplitted = policyName.Split('-');

        var feature = (FeatureOptions)Enum.Parse(typeof(FeatureOptions), policySplitted[0]);
        var permission = (PermissionOptions)Enum.Parse(typeof(PermissionOptions), policySplitted[1]);

        return new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(feature, permission))
            .Build();
    }
}
