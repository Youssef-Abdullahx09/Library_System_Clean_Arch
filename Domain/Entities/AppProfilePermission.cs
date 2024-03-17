namespace Domain.Entities;

public class AppProfilePermission
{
    public int Id { get; set; }
    public int AppProfileId { get; set; }
    public AppProfile AppProfile { get; set; }
    public AppFeaturePermission AppFeaturePermission { get; set; }
}
