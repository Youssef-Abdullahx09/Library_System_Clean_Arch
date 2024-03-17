namespace Infrastructure.Authorizations;

public interface IPermissionService
{
    Task<HashSet<FeaturePermission>> GetPermissionAsync(int currentProfileId);
}
