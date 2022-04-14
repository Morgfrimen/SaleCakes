using Data.Dto;
using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IAuthorizationUserRepositories : IBaseCrud<AuthorizationUserDto, Guid>
{
    public Task<Result<AuthorizationUserDto>> GetAuthorizationUserDtoByLoginAsync(string login);
}