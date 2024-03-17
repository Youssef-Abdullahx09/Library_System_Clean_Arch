namespace Domain.Entities;

public class AppUser
{

    public string Id { get; set; }
    public string Email { get; set; }
    public string PasswordHashed { get; set; }
    public ICollection<AppProfile> AppProfiles { get; set; }
}
