using Data.Context;
using Data.Dto;
using Data.Entries;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;

namespace Data.Repositories;

public class DecorRepositories : RepositoriesBase, IDecorRepositories
{
    public DecorRepositories(SaleCakesDbContext context) : base(context)
    {
    }

    public async Task<Result<Guid>> AddEntryAsync(DecorDto entity)
    {
        var decorEntry = new DecorEntry
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price
        };

        var newEntry = await DbContext.DecorsEntries.AddAsync(decorEntry);
        await DbContext.SaveChangesAsync();

        return new Result<Guid>(newEntry.Entity.Id);
    }

    public async Task<Result<bool>> DeleteEntryAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Guid>> UpdateEntryAsync(DecorDto entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<DecorDto>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<DecorDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<DecorDto>> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}