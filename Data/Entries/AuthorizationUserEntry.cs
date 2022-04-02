namespace Data.Entries;

internal class AuthorizationUserEntry
{
    internal AuthorizationUserEntry()
    {
        OrderClientOrderConditesNavigations = new HashSet<OrderClientEntry>();
        OrderClientOrderEmoloyeeNavigations = new HashSet<OrderClientEntry>();
    }

    internal Guid Id { get; set; }
    internal Guid? UserGuid { get; set; }
    internal string UserLogin { get; set; } = null!;
    internal string UserPassword { get; set; } = null!;
    internal DateTime? CreatedAt { get; set; }

    internal virtual AppUserEntry UserGu { get; set; }
    internal virtual EmployeeEntry Employee { get; set; }
    internal virtual ICollection<OrderClientEntry> OrderClientOrderConditesNavigations { get; set; }
    internal virtual ICollection<OrderClientEntry> OrderClientOrderEmoloyeeNavigations { get; set; }
}