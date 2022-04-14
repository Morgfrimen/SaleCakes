using Data.Context;
using Data.Dto;
using Data.Repositories.Abstract;
using Shared.Dto;

namespace Data.Repositories;

public class ClientRepositories : RepositoriesBase, IBaseCrud<ClientDto, Guid>
{
    public ClientRepositories(SaleCakesDbContext context) : base(context)
    {
    }

    public async Task<Result<Guid>> AddEntryAsync(ClientDto entity)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public async Task<Result<bool>> DeleteEntryAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Guid>> UpdateEntryAsync(ClientDto entityDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<ClientDto>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<ClientDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> ClearTableAsync()
    {
        throw new NotImplementedException();
    }
}