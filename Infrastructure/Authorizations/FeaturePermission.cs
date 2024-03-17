using Domain.Enums;

namespace Infrastructure.Authorizations;

public class FeaturePermission
{
    public FeatureOptions Feature { get; set; }
    public PermissionOptions Permission { get; set; }
}
