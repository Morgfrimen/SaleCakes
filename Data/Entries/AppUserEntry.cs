namespace Data.Entries;

internal sealed class AppUserEntry
{
    internal AppUserEntry()
    {
        AuthorizationUsers = new HashSet<AuthorizationUserEntry>();
    }

    internal Guid Id { get; set; }
    internal string? UserRole { get; set; }

    internal ICollection<AuthorizationUserEntry> AuthorizationUsers { get; set; }
}