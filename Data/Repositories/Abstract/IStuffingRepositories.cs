#nullable enable
using Data.Dto;
using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IStuffingRepositories : IBaseCrud<StuffingDto, Guid>
{
    Task<Result<StuffingDto?>> GetByNameAsync(string name);
}