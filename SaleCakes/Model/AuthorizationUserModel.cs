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

    public Guid Id { get; set; }
    public AppUsersModel AppUsers { get; set; }
    public string UserLogin { get; set; }
    public string UserPassword { get; set; }
    public DateTime CreatedAt { get; set; }
}