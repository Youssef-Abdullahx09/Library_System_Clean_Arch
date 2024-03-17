using Domain.Enums;

namespace Infrastructure.Authorizations;

public class ClaimedUser
{
    public ClaimedUser(string userId,
        string name,
        ProfileOptions currentProfile,
        List<ProfileOptions> profiles)
    {
        UserId = userId;
        Name = name;
        CurrentProfile = currentProfile;
        Profiles = profiles;
    }

    public string UserId { get; }
    public string Name { get; }
    public ProfileOptions CurrentProfile { get; set; }
    public List<ProfileOptions> Profiles { get; set; }
}
