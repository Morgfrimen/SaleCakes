namespace Data.Entries;

internal class AppUserEntry
{
    internal AppUserEntry()
    {
        AuthorizationUsers = new HashSet<AuthorizationUserEntry>();
    }

    internal Guid Id { get; set; }
    internal string UserRole { get; set; }

    internal virtual ICollection<AuthorizationUserEntry> AuthorizationUsers { get; set; }
}