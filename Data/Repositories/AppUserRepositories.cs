#nullable enable
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
            AppUserEntry? appUserEntry = new()
            {
                UserRole = entity.UserRole
            };

            var newEntry = await DbContext.AppUsersEntries.AddAsync(appUserEntry);
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
            var deletedEntry = await DbContext.AppUsersEntries.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);

            if (deletedEntry is null)
            {
                return new Result<bool>(false);
            }

            _ = DbContext.AppUsersEntries.Remove(deletedEntry);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public async Task<Result<Guid>> UpdateEntryAsync(RoleUserDto entityDto)
    {
        try
        {
            AppUserEntry? updateModel = new()
            {
                Id = entityDto.Id,
                UserRole = entityDto.UserRole
            };

            var result = DbContext.AppUsersEntries.Update(updateModel);
            _ = await DbContext.SaveChangesAsync();
            result.State = EntityState.Detached;
            return new Result<Guid>(result.Entity.Id);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public Task<Result<RoleUserDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            var resultEntry = DbContext.AppUsersEntries.AsNoTracking()
                .Where(item => item.Id == id)
                .Select(item => new RoleUserDto(item.Id, item.UserRole))
                .FirstOrDefault();

            return Task.FromResult(new Result<RoleUserDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<RoleUserDto?>(new Error(ex.Message)));
        }
    }

    public async Task<Result<IEnumerable<RoleUserDto>>> GetAllAsync()
    {
        try
        {
            var result = DbContext.AppUsersEntries.AsNoTracking().Select(item => new RoleUserDto(item.Id, item.UserRole));
            _ = await DbContext.SaveChangesAsync();
            return new Result<IEnumerable<RoleUserDto>>(result);
        }
        catch (Exception ex)
        {
            return new Result<IEnumerable<RoleUserDto>>(new Error(ex.Message));
        }
    }

    public async Task<Result<bool>> ClearTableAsync()
    {
        try
        {
            DbContext.AppUsersEntries.RemoveRange(DbContext.AppUsersEntries);
            _ = await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public Task<Result<RoleUserDto?>> GetByRoleAsync(string role)
    {
        try
        {
            var resultEntry = DbContext.AppUsersEntries.AsNoTracking()
                .Where(item => item.UserRole == role)
                .Select(item => new RoleUserDto(item.Id, item.UserRole))
                .FirstOrDefault();

            return Task.FromResult(new Result<RoleUserDto?>(resultEntry));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<RoleUserDto?>(new Error(ex.Message)));
        }
    }
}