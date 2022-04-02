#nullable enable
using Data.Context;
using Data.Dto;
using Data.Entries;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;

namespace Data.Repositories;

public class TierRepositories : RepositoriesBase, ITierRepositories
{
    public TierRepositories(SaleCakesDbContext context) : base(context)
    {
    }

    public async Task<Result<Guid>> AddEntryAsync(TiersDto entity)
    {
        try
        {
            StuffingEntry? stuffingEntry = new()
            {
                Id = entity.Id,
                Name = entity.StuffingDto.Name,
                Price = entity.StuffingDto.Price
            };

            ShortcakeEntry? shortcakeEntry = new()
            {
                Id = entity.Id,
                Name = entity.ShortcakeDto.Name,
                Price = entity.ShortcakeDto.Price
            };

            DecorEntry? decorEntry = new()
            {
                Id = entity.Id,
                Name = entity.DecorDto.Name,
                Price = entity.DecorDto.Price
            };

            var tierEntry = new TierEntry
            {
                Id = entity.Id,
                StuffingEntry = stuffingEntry,
                ShortcakeEntry = shortcakeEntry,
                DecorEntry = decorEntry
            };

            var newEntry = await DbContext.TiersEntries.AddAsync(tierEntry);
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
            var deletedEntry = await DbContext.TiersEntries.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);

            if (deletedEntry is null)
            {
                return new Result<bool>(false);
            }

            _ = DbContext.TiersEntries.Remove(deletedEntry);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public async Task<Result<Guid>> UpdateEntryAsync(TiersDto entity)
    {
        try
        {
            StuffingEntry? stuffingEntry = new()
            {
                Id = entity.Id,
                Name = entity.StuffingDto.Name,
                Price = entity.StuffingDto.Price
            };

            ShortcakeEntry? shortcakeEntry = new()
            {
                Id = entity.Id,
                Name = entity.ShortcakeDto.Name,
                Price = entity.ShortcakeDto.Price
            };

            DecorEntry? decorEntry = new()
            {
                Id = entity.Id,
                Name = entity.DecorDto.Name,
                Price = entity.DecorDto.Price
            };

            TierEntry? updateModel = new()
            {
                Id = entity.Id,
                StuffingEntry = stuffingEntry,
                ShortcakeEntry = shortcakeEntry,
                DecorEntry = decorEntry
            };

            var result = DbContext.TiersEntries.Update(updateModel);
            _ = await DbContext.SaveChangesAsync();
            result.State = EntityState.Detached;
            return new Result<Guid>(result.Entity.Id);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public Task<Result<TiersDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            var resultEntry = DbContext.TiersEntries.AsNoTracking()
                .Where(item => item.Id == id)
                .Select(item => new TiersDto(item.Id,
                    new StuffingDto(item.StuffingEntry.Id, item.StuffingEntry.Name, item.StuffingEntry.Price),
                    new DecorDto(item.DecorEntry.Id, item.DecorEntry.Name, item.DecorEntry.Price),
                    new ShortcakeDto(item.ShortcakeEntry.Id, item.ShortcakeEntry.Name, item.ShortcakeEntry.Price)))
                .FirstOrDefault();

            return Task.FromResult(new Result<TiersDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<TiersDto?>(new Error(ex.Message)));
        }
    }

    public async Task<Result<IEnumerable<TiersDto>>> GetAllAsync()
    {
        try
        {
            var result = DbContext.TiersEntries.AsNoTracking()
                .Select(item => new TiersDto(item.Id,
                    new StuffingDto(item.StuffingEntry.Id, item.StuffingEntry.Name, item.StuffingEntry.Price),
                    new DecorDto(item.DecorEntry.Id, item.DecorEntry.Name, item.DecorEntry.Price),
                    new ShortcakeDto(item.ShortcakeEntry.Id, item.ShortcakeEntry.Name, item.ShortcakeEntry.Price)));
            _ = await DbContext.SaveChangesAsync();
            return new Result<IEnumerable<TiersDto>>(result);
        }
        catch (Exception ex)
        {
            return new Result<IEnumerable<TiersDto>>(new Error(ex.Message));
        }
    }

    public async Task<Result<bool>> ClearTableAsync()
    {
        try
        {
            DbContext.TiersEntries.RemoveRange(DbContext.TiersEntries);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }
}