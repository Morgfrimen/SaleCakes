using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Legacy.Dto;
using Data.Legacy.Resositoryes;
using Xunit;

namespace UnitTestsLegacy;

public class RepositoryAuthorizedUserTests
{
    private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    [Fact]
    public async void Authorized_Test()
    {
        var roleDto = await AddRole();

        var login = "Santay";
        var password = "32213221";
        var createAt = DateTime.Now;
        var repository = new UserAuthorizationRepos(ConnectionString);
        var authorizationUserDto = new AuthorizationUserDto(roleDto.Id, login, password, createAt);

        Assert.True(await repository.AddAsync(authorizationUserDto));

        var collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var deletedDro = collection.FirstOrDefault(item => item.UserLogin == login);
        Assert.NotNull(deletedDro);

        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));

        roleDto = await AddRole();
        authorizationUserDto = new AuthorizationUserDto(roleDto.Id, login, password, createAt);
        Assert.True(await repository.AddAsync(authorizationUserDto));

        collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var updateRoleDto = collection.FirstOrDefault(item => item.UserLogin == login);
        updateRoleDto = new AuthorizationUserDto(updateRoleDto.Id, roleDto.Id, "updateRoleDto.Id", "3221", DateTime.Now);
        Assert.True(await repository.UpdateAsync(updateRoleDto));

        var getDto = await repository.GetByIdAsync(updateRoleDto.Id);

        Assert.Equal(getDto.Id, updateRoleDto.Id);

        Assert.True(await repository.DeleteAsync(updateRoleDto.Id));

        collection = await repository.GetAllAsync();

        if (collection is null)
        {
            return;
        }

        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));
    }

    private async Task<RoleUserDto> AddRole()
    {
        var role = "Директор";
        var repository = new RoleUserRepos(ConnectionString);
        var roleUserDto = new RoleUserDto(role);

        Assert.True(await repository.AddAsync(roleUserDto));
        var collection = await repository.GetAllAsync();
        return collection.FirstOrDefault(item => item.UserRole == role)!;
    }
}