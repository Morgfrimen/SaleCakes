#nullable enable
using Data.Context;
using Data.Dto;
using Data.Entries;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;

namespace Data.Repositories;

public class ShortcakeRepositories : RepositoriesBase, IShortcakeRepositories
{
    public ShortcakeRepositories(SaleCakesDbContext context) : base(context)
    {
    }

    public async Task<Result<Guid>> AddEntryAsync(ShortcakeDto entity)
    {
        try
        {
            ShortcakeEntry? decorEntry = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };

            var newEntry = await DbContext.ShortcakesEntries.AddAsync(decorEntry);
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
            var deletedEntry = await DbContext.ShortcakesEntries.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);

            if (deletedEntry is null)
            {
                return new Result<bool>(false);
            }

            _ = DbContext.ShortcakesEntries.Remove(deletedEntry);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public async Task<Result<Guid>> UpdateEntryAsync(ShortcakeDto entityDto)
    {
        try
        {
            ShortcakeEntry? updateModel = new()
            {
                Id = entityDto.Id,
                Name = entityDto.Name,
                Price = entityDto.Price
            };

            var result = DbContext.ShortcakesEntries.Update(updateModel);
            _ = await DbContext.SaveChangesAsync();
            result.State = EntityState.Detached;
            return new Result<Guid>(result.Entity.Id);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public Task<Result<ShortcakeDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            var resultEntry = DbContext.ShortcakesEntries.AsNoTracking()
                .Where(item => item.Id == id)
                .Select(item => new ShortcakeDto(item.Id, item.Name, item.Price))
                .FirstOrDefault();

            return Task.FromResult(new Result<ShortcakeDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<ShortcakeDto?>(new Error(ex.Message)));
        }
    }

    public async Task<Result<IEnumerable<ShortcakeDto>>> GetAllAsync()
    {
        try
        {
            var result = DbContext.ShortcakesEntries.AsNoTracking().Select(item => new ShortcakeDto(item.Id, item.Name, item.Price));
            _ = await DbContext.SaveChangesAsync();
            return new Result<IEnumerable<ShortcakeDto>>(result);
        }
        catch (Exception ex)
        {
            return new Result<IEnumerable<ShortcakeDto>>(new Error(ex.Message));
        }
    }

    public async Task<Result<bool>> ClearTableAsync()
    {
        try
        {
            DbContext.ShortcakesEntries.RemoveRange(DbContext.ShortcakesEntries);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public Task<Result<ShortcakeDto?>> GetByNameAsync(string name)
    {
        try
        {
            var resultEntry = DbContext.ShortcakesEntries.AsNoTracking()
                .Where(item => item.Name == name)
                .Select(item => new ShortcakeDto(item.Id, item.Name, item.Price))
                .FirstOrDefault();

            return Task.FromResult(new Result<ShortcakeDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<ShortcakeDto?>(new Error(ex.Message)));
        }
    }
}