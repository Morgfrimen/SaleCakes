using Data.Dto;
using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IDecorRepositories : IBaseCrud<DecorDto>
{
    Result<DecorDto> GetByName(string name);
}