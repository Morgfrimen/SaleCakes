namespace Data.Entries;

internal class EmployeeEntry
{
    internal Guid Id { get; set; }
    internal Guid? AutorizedData { get; set; }
    internal string EmployeeName { get; set; } = null!;
    internal string EmployeeSurname { get; set; } = null!;
    internal string? EmployeePatronymic { get; set; }
    internal string EmployeePhone { get; set; } = null!;
    internal string EmployeeEmail { get; set; } = null!;
    internal bool IsWork { get; set; }

    internal virtual AuthorizationUserEntry? AutorizedDataNavigation { get; set; }
}