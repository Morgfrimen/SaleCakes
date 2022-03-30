using System;

namespace SaleCakes.Model;

internal class ModelAppUsers
{
    public ModelAppUsers(Guid id, string userRole)
    {
        Id = id;
        UserRole = userRole;
    }

    public Guid Id { get; }
    public string UserRole { get; }
}