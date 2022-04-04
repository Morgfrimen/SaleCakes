using System;

namespace SaleCakes.Model;

public class AppUsersModel
{
    public AppUsersModel(Guid id, string userRole)
    {
        Id = id;
        UserRole = userRole;
    }

    public AppUsersModel()
    {
    }

    public Guid Id { get; }
    public string UserRole { get; }
}