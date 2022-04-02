#nullable enable
using Data.Dto;
using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IDecorRepositories : IBaseCrud<DecorDto, Guid>
{
    Task<Result<DecorDto?>> GetByNameAsync(string name);
}