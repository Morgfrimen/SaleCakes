namespace Data.Entries;

public class AppUserEntry
{
    public AppUserEntry()
    {
        AuthorizationUsers = new HashSet<AuthorizationUserEntry>();
    }

    public Guid Id { get; set; }
    public string? UserRole { get; set; }

    public virtual ICollection<AuthorizationUserEntry> AuthorizationUsers { get; set; }
}