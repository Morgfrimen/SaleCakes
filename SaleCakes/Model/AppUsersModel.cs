using System;

namespace SaleCakes.Model;

internal class AppUsersModel
{
    public AppUsersModel(Guid id, string userRole)
    {
        Id = id;
        UserRole = userRole;
    }

    public Guid Id { get; }
    public string UserRole { get; }
}