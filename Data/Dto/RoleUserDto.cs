namespace Data.Dto;

public class RoleUserDto
{
    public RoleUserDto(Guid id, string? userRole) : this(userRole)
    {
        Id = id;
    }

    public RoleUserDto(string? userRole)
    {
        UserRole = userRole;
    }

    public Guid Id { get; }
    public string? UserRole { get; }
}