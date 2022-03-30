using System;

namespace SaleCakes.Model;

internal class ModelAuthorizationUser
{
    public ModelAuthorizationUser(Guid id, Guid appUsers, string userLogin, string userPassword, DateTime createdAt)
    {
        Id = id;
        AppUsers = appUsers;
        UserLogin = userLogin;
        UserPassword = userPassword;
        CreatedAt = createdAt;
    }

    public Guid Id { get; }
    public Guid AppUsers { get; }
    public string UserLogin { get; }
    public string UserPassword { get; }
    public DateTime CreatedAt { get; }
}