namespace Domain.Entities;

public class AppFeature
{
    public AppFeature()
    {
        AppPermissions = new HashSet<AppPermission>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameAr { get; set; }
    public IReadOnlyCollection<AppPermission> AppPermissions { get; set; }
}
