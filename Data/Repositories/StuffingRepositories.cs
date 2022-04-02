#nullable enable
using Data.Context;
using Data.Dto;
using Data.Entries;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;

namespace Data.Repositories;

public class StuffingRepositories : RepositoriesBase, IStuffingRepositories
{
    public StuffingRepositories(SaleCakesDbContext context) : base(context)
    {
    }

    public async Task<Result<Guid>> AddEntryAsync(StuffingDto entity)
    {
        try
        {
            StuffingEntry? decorEntry = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };

            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<StuffingEntry>? newEntry = await DbContext.StuffingsEntries.AddAsync(decorEntry);
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
            StuffingEntry? deletedEntry = await DbContext.StuffingsEntries.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);

            if (deletedEntry is null)
            {
                return new Result<bool>(false);
            }

            _ = DbContext.StuffingsEntries.Remove(deletedEntry);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public async Task<Result<Guid>> UpdateEntryAsync(StuffingDto entity)
    {
        try
        {
            StuffingEntry? updateModel = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };

            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<StuffingEntry>? result = DbContext.StuffingsEntries.Update(updateModel);
            _ = await DbContext.SaveChangesAsync();
            result.State = EntityState.Detached;
            return new Result<Guid>(result.Entity.Id);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public Task<Result<StuffingDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            StuffingDto? resultEntry = DbContext.StuffingsEntries.AsNoTracking()
                .Where(item => item.Id == id)
                .Select(item => new StuffingDto(item.Id, item.Name, item.Price))
                .FirstOrDefault();

            return Task.FromResult(new Result<StuffingDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<StuffingDto?>(new Error(ex.Message)));
        }
    }

    public async Task<Result<IEnumerable<StuffingDto>>> GetAllAsync()
    {
        try
        {
            IQueryable<StuffingDto>? result = DbContext.StuffingsEntries.AsNoTracking().Select(item => new StuffingDto(item.Id, item.Name, item.Price));
            _ = await DbContext.SaveChangesAsync();
            return new Result<IEnumerable<StuffingDto>>(result);
        }
        catch (Exception ex)
        {
            return new Result<IEnumerable<StuffingDto>>(new Error(ex.Message));
        }
    }

    public async Task<Result<bool>> ClearTableAsync()
    {
        try
        {
            DbContext.StuffingsEntries.RemoveRange(DbContext.StuffingsEntries);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public Task<Result<StuffingDto?>> GetByNameAsync(string name)
    {
        try
        {
            StuffingDto? resultEntry = DbContext.StuffingsEntries.AsNoTracking()
                .Where(item => item.Name == name)
                .Select(item => new StuffingDto(item.Id, item.Name, item.Price))
                .FirstOrDefault();

            return Task.FromResult(new Result<StuffingDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<StuffingDto?>(new Error(ex.Message)));
        }
    }
}