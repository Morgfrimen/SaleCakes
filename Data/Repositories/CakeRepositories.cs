#nullable enable
using Data.Context;
using Data.Dto;
using Data.Entries;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;

namespace Data.Repositories;

public class CakeRepositories : RepositoriesBase, ICakeRepositories
{
    public CakeRepositories(SaleCakesDbContext context) : base(context)
    {
    }

    public async Task<Result<Guid>> AddEntryAsync(CakeDto entity)
    {
        try
        {
            var decorEntry = new CakeEntry()
            {
                Id = entity.Id,
                Weight = entity.Weight,
                Name = entity.Name
            };

            var cakeDesigns = new List<CakeDesign>();

            foreach (var tiersDto in entity.TiersId)
            {
                var cakeDesign = new CakeDesign();

                cakeDesign.Tier = new TierEntry()
                {
                    Id = tiersDto.Id,
                    DecorEntry = new DecorEntry()
                    {
                        Id = tiersDto.DecorDto.Id,
                        Name = tiersDto.DecorDto.Name,
                        Price = tiersDto.DecorDto.Price
                    },
                    ShortcakeEntry = new ShortcakeEntry()
                    {
                        Id = tiersDto.ShortcakeDto.Id,
                        Name = tiersDto.ShortcakeDto.Name,
                        Price = tiersDto.ShortcakeDto.Price
                    },
                    StuffingEntry = new StuffingEntry()
                    {
                        Id = tiersDto.StuffingDto.Id,
                        Name = tiersDto.StuffingDto.Name,
                        Price = tiersDto.StuffingDto.Price
                    }
                };
                cakeDesign.Cake = decorEntry;
                cakeDesigns.Add(cakeDesign);
            }

            decorEntry.CakeDesigns = cakeDesigns;

            var newEntry = await DbContext.CakesEntries.AddAsync(decorEntry);
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
            var deletedEntry = await DbContext.CakesEntries.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);

            if (deletedEntry is null)
            {
                return new Result<bool>(false);
            }

            _ = DbContext.CakesEntries.Remove(deletedEntry);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public Task<Result<Guid>> UpdateEntryAsync(CakeDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result<CakeDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            var resultEntry = DbContext.CakesEntries.AsNoTracking()
                .Where(item => item.Id == id)
                .Select(item => new CakeDto(item.Id, item.Weight,default,item.Name))
                .FirstOrDefault();
            //TODO: Tiers

            return Task.FromResult(new Result<CakeDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<CakeDto?>(new Error(ex.Message)));
        }
    }

    public Task<Result<IEnumerable<CakeDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> ClearTableAsync()
    {
        throw new NotImplementedException();
    }
}