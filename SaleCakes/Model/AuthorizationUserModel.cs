using System;

namespace SaleCakes.Model;

public class AuthorizationUserModel
{
    public AuthorizationUserModel(Guid id, AppUsersModel appUsers, string userLogin, string userPassword, DateTime createdAt)
    {
        Id = id;
        AppUsers = appUsers;
        UserLogin = userLogin;
        UserPassword = userPassword;
        CreatedAt = createdAt;
    }

    public AuthorizationUserModel()
    {
    }

    public Guid Id { get; }
    public AppUsersModel AppUsers { get; init; }
    public string UserLogin { get; }
    public string UserPassword { get; }
    public DateTime CreatedAt { get; }
}