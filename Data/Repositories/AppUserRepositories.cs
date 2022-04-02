using Data.Context;
using Data.Dto;
using Data.Entries;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;

namespace Data.Repositories;

public class AppUserRepositories : RepositoriesBase, IAppUserRepositories
{
    public AppUserRepositories(SaleCakesDbContext context) : base(context)
    {
    }

    public async Task<Result<Guid>> AddEntryAsync(RoleUserDto entity)
    {
        try
        {
            var decorEntry = new AppUserEntry
            {
                Id = entity.Id,
                UserRole = entity.UserRole
            };

            var newEntry = await DbContext.AppUsersEntries.AddAsync(decorEntry);
            _ = await DbContext.SaveChangesAsync();
            newEntry.State = EntityState.Detached;
            return new Result<Guid>(newEntry.Entity.Id);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public Task<Result<bool>> DeleteEntryAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Guid>> UpdateEntryAsync(RoleUserDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RoleUserDto>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<RoleUserDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> ClearTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<RoleUserDto>> GetByRoleAsync(string role)
    {
        throw new NotImplementedException();
    }
}