#nullable enable
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
        try
        {
            DecorEntry? decorEntry = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };

            var newEntry = await DbContext.DecorsEntries.AddAsync(decorEntry);
            _ = await DbContext.SaveChangesAsync();
            newEntry.State = EntityState.Detached;
            return new Result<Guid>(newEntry.Entity.Id);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public async Task<Result<bool>> DeleteEntryAsync(Guid id)
    {
        try
        {
            var deletedEntry = await DbContext.DecorsEntries.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);

            if (deletedEntry is null)
            {
                return new Result<bool>(false);
            }

            _ = DbContext.DecorsEntries.Remove(deletedEntry);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public async Task<Result<Guid>> UpdateEntryAsync(DecorDto entityDto)
    {
        try
        {
            DecorEntry? updateModel = new()
            {
                Id = entityDto.Id,
                Name = entityDto.Name,
                Price = entityDto.Price
            };

            var result = DbContext.DecorsEntries.Update(updateModel);
            _ = await DbContext.SaveChangesAsync();
            result.State = EntityState.Detached;
            return new Result<Guid>(result.Entity.Id);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public Task<Result<DecorDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            var resultEntry = DbContext.DecorsEntries.AsNoTracking()
                .Where(item => item.Id == id)
                .Select(item => new DecorDto(item.Id, item.Name, item.Price))
                .FirstOrDefault();

            return Task.FromResult(new Result<DecorDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<DecorDto?>(new Error(ex.Message)));
        }
    }

    public async Task<Result<IEnumerable<DecorDto>>> GetAllAsync()
    {
        try
        {
            var result = DbContext.DecorsEntries.AsNoTracking().Select(item => new DecorDto(item.Id, item.Name, item.Price));
            _ = await DbContext.SaveChangesAsync();
            return new Result<IEnumerable<DecorDto>>(result);
        }
        catch (Exception ex)
        {
            return new Result<IEnumerable<DecorDto>>(new Error(ex.Message));
        }
    }

    public async Task<Result<bool>> ClearTableAsync()
    {
        try
        {
            DbContext.DecorsEntries.RemoveRange(DbContext.DecorsEntries);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public Task<Result<DecorDto?>> GetByNameAsync(string name)
    {
        try
        {
            var resultEntry = DbContext.DecorsEntries.AsNoTracking()
                .Where(item => item.Name == name)
                .Select(item => new DecorDto(item.Id, item.Name, item.Price))
                .FirstOrDefault();

            return Task.FromResult(new Result<DecorDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<DecorDto?>(new Error(ex.Message)));
        }
    }
}