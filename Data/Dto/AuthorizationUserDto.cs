namespace Data.Dto;

public class AuthorizationUserDto
{
    public AuthorizationUserDto(RoleUserDto appUsers, string userLogin, string userPassword, DateTime createdAt) : this(userLogin, userPassword, createdAt)
    {
        AppUsers = appUsers;
    }

    public AuthorizationUserDto(string userLogin, string userPassword, DateTime createdAt)
    {
        UserLogin = userLogin;
        UserPassword = userPassword;
        CreatedAt = createdAt;
    }

    public AuthorizationUserDto(Guid id, RoleUserDto appUsers, string userLogin, string userPassword, DateTime createdAt)
        : this(appUsers, userLogin, userPassword, createdAt)
    {
        Id = id;
    }

    public Guid Id { get; }
    public RoleUserDto AppUsers { get; }
    public string UserLogin { get; }
    public string UserPassword { get; }
    public DateTime CreatedAt { get; }
}