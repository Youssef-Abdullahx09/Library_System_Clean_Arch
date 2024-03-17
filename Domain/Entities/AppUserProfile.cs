namespace Domain.Entities;

public class AppUserProfile
{
    public string AppUserId { get; }
    public int AppProfileId { get; }
    public AppUser AppUser { get; }
    public AppProfile AppProfile { get; }
}
