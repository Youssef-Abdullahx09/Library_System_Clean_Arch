namespace Domain.Entities;

public class AppFeaturePermission
{
    public AppFeaturePermission()
    {
        AppProfiles = new HashSet<AppProfile>();
    }
    public int AppFeatureId { get; set; }
    public int AppPermissionId { get; set; }
    public AppFeature AppFeature { get; set; }
    public AppPermission AppPermission { get; set; }
    public IReadOnlyCollection<AppProfile> AppProfiles { get; set; }
}
