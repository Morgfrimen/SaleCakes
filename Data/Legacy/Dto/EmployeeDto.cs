namespace Data.Legacy.Dto;

public record EmployeeDto
{
    public EmployeeDto(Guid id, Guid autorizedUserId, string firstName, string lastName, string patronymic, string phone, string email) : this(autorizedUserId, firstName, lastName, patronymic, phone, email)
    {
        Id = id;
    }

    public EmployeeDto(Guid autorizedUserId, string firstName, string lastName, string? patronymic, string phone, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Phone = phone;
        Email = email;
        AutorizedUserId = autorizedUserId;
    }

    public Guid Id { get; }
    public Guid AutorizedUserId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string? Patronymic { get; }
    public string Phone { get; }
    public string Email { get; }
}