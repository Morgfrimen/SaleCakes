#nullable enable
using Data.Dto;
using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IShortcakeRepositories : IBaseCrud<ShortcakeDto, Guid>
{
    Task<Result<ShortcakeDto?>> GetByNameAsync(string name);
}