using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Dto;
using Data.Resositoryes;
using Xunit;

namespace UnitTests;

public class RepositoryEmployeeTests
{
    private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    [Fact]
    public async void Add_Employee_Test()
    {
        var repository = new EmployeeRepos(ConnectionString);

        var userAuthorizationUserDto = await AddAuthorizationUser();

        var employyeDto = new EmployeeDto(userAuthorizationUserDto.Id,
            "Алехандро",
            "Багратионович",
            "Васильевич",
            "8-800-553-55-55",
            "morg@ru.con");

        Assert.True(await repository.AddAsync(employyeDto));

        var collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var deletedDro = collection.FirstOrDefault(item => item.AutorizedUserId == userAuthorizationUserDto.Id);
        Assert.NotNull(deletedDro);

        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));

        repository = new EmployeeRepos(ConnectionString);

        userAuthorizationUserDto = await AddAuthorizationUser();

        employyeDto = new EmployeeDto(userAuthorizationUserDto.Id,
            "Алехандро",
            "Багратионович",
            "Васильевич",
            "8-800-553-55-55",
            "morg@ru.con");

        Assert.True(await repository.AddAsync(employyeDto));

        collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var updateEmployeeDto = collection.FirstOrDefault(item => item.AutorizedUserId == userAuthorizationUserDto.Id);

        updateEmployeeDto = new EmployeeDto(updateEmployeeDto.Id,
            userAuthorizationUserDto.Id,
            "5555",
            "Багратионович",
            "Васильевич",
            "8-800-553-55-55",
            "santa@ru.con");
        Assert.True(await repository.UpdateAsync(updateEmployeeDto));

        var getDto = await repository.GetByIdAsync(updateEmployeeDto.Id);

        Assert.Equal(getDto.Id, updateEmployeeDto.Id);

        Assert.True(await repository.DeleteAsync(updateEmployeeDto.Id));

        collection = await repository.GetAllAsync();
        if (collection is null)
            return;
        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));
    }

    private async Task<RoleUserDto> AddRole()
    {
        var role = "Директор";
        var repository = new RoleUserRepos(ConnectionString);
        var roleUserDto = new RoleUserDto(role);

        await repository.AddAsync(roleUserDto);
        var collection = await repository.GetAllAsync();
        return collection!.FirstOrDefault(item => item.UserRole == role)!;
    }

    private async Task<AuthorizationUserDto> AddAuthorizationUser()
    {
        var roleDto = await AddRole();
        var login = "Santay";
        var password = "32213221";
        var createAt = DateTime.Now;
        var repository = new UserAuthorizationRepos(ConnectionString);

        var authorizationUserDto = new AuthorizationUserDto(roleDto.Id, login, password, createAt);
        await repository.AddAsync(authorizationUserDto);

        var collection = await repository.GetAllAsync();
        return collection!.FirstOrDefault(item => item.UserLogin == login)!;
    }
}