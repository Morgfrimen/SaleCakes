#nullable enable
using Data.Context;
using Data.Dto;
using Data.Entries;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;

namespace Data.Repositories;

public class AuthorizationUserRepositories : RepositoriesBase,IAuthorizationUserRepositories
{
    public AuthorizationUserRepositories(SaleCakesDbContext context) : base(context)
    {
    }

    public async Task<Result<Guid>> AddEntryAsync(AuthorizationUserDto entity)
    {
        try
        {
            var roleEntry = new AppUserEntry() { Id = entity.AppUsers.Id, UserRole = entity.AppUsers.UserRole };
            var resultRole = await DbContext.AppUsersEntries.FirstOrDefaultAsync(item => item.UserRole == roleEntry.UserRole);
            if (resultRole is null) return new Result<Guid>(new Error("Такой роли не найдено"));

            var authorizationEntry = new AuthorizationUserEntry()
            {
                CreatedAt = DateTime.Now,
                UserLogin = entity.UserLogin,
                UserPassword = entity.UserPassword,
                UserGu = resultRole
            };

            var result = await DbContext.AuthorizationUsersEntries.AddAsync(authorizationEntry);
            await DbContext.SaveChangesAsync();
            result.State = EntityState.Detached;
            return new Result<Guid>(result.Entity.Id);

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
            var first = await DbContext.AuthorizationUsersEntries.FindAsync(id);
            if(first is null) 
                return new Result<bool>(false);

            _ = DbContext.AuthorizationUsersEntries.Remove(first);
            await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public async Task<Result<Guid>> UpdateEntryAsync(AuthorizationUserDto entityDto)
    {
        try
        {
            var firstEntry = await DbContext.AuthorizationUsersEntries.FirstOrDefaultAsync(item => item.Id == entityDto.Id);

            if (firstEntry == null)
                return new Result<Guid>(new Error("Такого пользователя не найдено"));

            firstEntry.UserLogin = entityDto.UserLogin;
            firstEntry.UserPassword = entityDto.UserPassword;
            firstEntry.CreatedAt = entityDto.CreatedAt;

            var result = DbContext.AuthorizationUsersEntries.Update(firstEntry);
            await DbContext.SaveChangesAsync();
            result.State = EntityState.Detached;
            return new Result<Guid>(result.Entity.Id);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(new Error(ex.Message));
        }
    }

    public async Task<Result<AuthorizationUserDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            var result = await DbContext.AuthorizationUsersEntries.FirstOrDefaultAsync(item => item.Id == id);

            if (result == null)
                return new Result<AuthorizationUserDto?>(default(AuthorizationUserDto));

            var dtoRole = new RoleUserDto(result.UserGu.Id, result.UserGu.UserRole);
            var dtoUser = new AuthorizationUserDto(dtoRole, result.UserLogin, result.UserPassword, result.CreatedAt ?? default);
            return new Result<AuthorizationUserDto?>(dtoUser);
        }
        catch (Exception ex)
        {
            return new Result<AuthorizationUserDto?>(new Error(ex.Message));
        }
    }

    public Task<Result<IEnumerable<AuthorizationUserDto>>> GetAllAsync()
    {
        try
        {
            var result = DbContext.AuthorizationUsersEntries.Select(item =>
                new AuthorizationUserDto(new RoleUserDto(item.UserGu.Id, item.UserGu.UserRole), item.UserLogin, item.UserPassword, item.CreatedAt ?? default));
            return Task.FromResult(new Result<IEnumerable<AuthorizationUserDto>>(result));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new Result<IEnumerable<AuthorizationUserDto>>(new Error(ex.Message)));
        }
    }

    public async Task<Result<bool>> ClearTableAsync()
    {
        try
        {
            DbContext.AuthorizationUsersEntries.RemoveRange(DbContext.AuthorizationUsersEntries);
            await DbContext.SaveChangesAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(new Error(ex.Message));
        }
    }

    public async Task<Result<AuthorizationUserDto?>> GetAuthorizationUserDtoByLoginAsync(string login)
    {
        try
        {
            var result = await DbContext.AuthorizationUsersEntries.FirstOrDefaultAsync(item => item.UserLogin == login);
            var role = await DbContext.AppUsersEntries.FirstOrDefaultAsync(item => item.Id == result.UserGuid.Value);
            if (result is null)
                return new Result<AuthorizationUserDto?>(default(AuthorizationUserDto));
            var dto = new AuthorizationUserDto(new RoleUserDto(role.Id, role.UserRole), result.UserLogin, result.UserPassword, result.CreatedAt ?? default);
            return new Result<AuthorizationUserDto?>(dto);
        }
        catch (Exception e)
        {
            return new Result<AuthorizationUserDto?>(new Error(e.Message));
        }
    }
}