﻿namespace Data.Dto;

public class AuthorizationUserDto
{
    public AuthorizationUserDto(string userLogin, string userPassword, DateTime createdAt)
    {
        UserLogin = userLogin;
        UserPassword = userPassword;
        CreatedAt = createdAt;
    }

    public AuthorizationUserDto(Guid id, Guid appUsers, string userLogin, string userPassword, DateTime createdAt)
        : this(userLogin, userPassword, createdAt)
    {
        Id = id;
        AppUsers = appUsers;
    }

    public Guid Id { get; }
    public Guid AppUsers { get; }
    public string UserLogin { get; }
    public string UserPassword { get; }
    public DateTime CreatedAt { get; }
}