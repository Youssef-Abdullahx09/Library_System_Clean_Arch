namespace Domain.Entities;

public class AppPermission
{
    public AppPermission()
    {
        AppFeatures = new HashSet<AppFeature>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameAr { get; set; }
    public IReadOnlyCollection<AppFeature> AppFeatures { get; set; }
}
