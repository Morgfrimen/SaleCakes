using System.Data;
using System.Linq;
using Data.Dto;
using Data.Resositoryes;
using Xunit;

namespace UnitTests;

public class RepositoryRoleUserTests
{
    private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    [Fact]
    public async void Role_Test()
    {
        var role = "Директор";
        var repository = new RoleUserRepos(ConnectionString);
        var roleUserDto = new RoleUserDto(role);

        Assert.True(await repository.AddAsync(roleUserDto));

        var collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var deletedDro = collection.FirstOrDefault(item => item.UserRole == role);
        Assert.NotNull(deletedDro);

        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));

        Assert.True(await repository.AddAsync(roleUserDto));

        collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var updateRoleDto = collection.FirstOrDefault(item => item.UserRole == role);
        updateRoleDto = new RoleUserDto(updateRoleDto.Id, "Клиент");
        Assert.True(await repository.UpdateAsync(updateRoleDto));

        Assert.True(await repository.DeleteAsync(updateRoleDto.Id));
    }

}