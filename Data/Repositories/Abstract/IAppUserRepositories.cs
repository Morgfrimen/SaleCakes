using Data.Dto;
using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IAppUserRepositories : IBaseCrud<RoleUserDto, Guid>
{
    Task<Result<RoleUserDto?>> GetByRoleAsync(string role);
}