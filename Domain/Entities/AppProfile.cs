namespace Domain.Entities;

public class AppProfile
{
    public AppProfile()
    {
        AppUsers = new HashSet<AppUser>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameAr { get; set; }

    public IReadOnlyCollection<AppUser> AppUsers { get; set; }
    public IReadOnlyCollection<AppFeaturePermission> AppFeaturePermissions { get; set; }
}
