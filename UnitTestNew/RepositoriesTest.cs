using System;
using System.Collections.Generic;
using System.Linq;
using Data.Context;
using Data.Dto;
using Data.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Shared.Dto;
using UnitTestNew.TestSettings;
using Xunit;

namespace UnitTestNew;

[TestCaseOrderer("UnitTestNew.TestSettings.PriorityOrderer", "UnitTestNew")]
public class RepositoriesTest : IClassFixture<Startup>
{
    private readonly SaleCakesDbContext? _dbContext;
    private readonly IServiceProvider _serviceProvider;

    public RepositoriesTest(Startup fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
        _dbContext = _serviceProvider!.GetService<SaleCakesDbContext>();
    }

    [Fact]
    [PriorityTest(0)]
    public async void DecorRepositories_Success_Test()
    {
        var decorRepos = _serviceProvider.GetService<IDecorRepositories>()!;
        _ = await decorRepos.ClearTableAsync();

        DecorDto? expectedDecorDto = new("Test2", 500);
        var entryAsync = await decorRepos.AddEntryAsync(expectedDecorDto);
        Assert.True(entryAsync.ResultOperation != default);

        DecorDto? updateDecorDto = new(entryAsync.ResultOperation, "Форбс", 300);
        entryAsync = await decorRepos.UpdateEntryAsync(updateDecorDto);

        var findDto = await decorRepos.GetByNameAsync("Форбс");
        Assert.NotNull(findDto.ResultOperation);
        Assert.Equal(entryAsync.ResultOperation, findDto.ResultOperation!.Id);

        var getDto = await decorRepos.GetByIdAsync(findDto.ResultOperation.Id);
        Assert.Equal(getDto.ResultOperation.Name, findDto.ResultOperation.Name);
        Assert.Equal(getDto.ResultOperation.Price, findDto.ResultOperation.Price);

        Result<IEnumerable<DecorDto>>? collection = await decorRepos.GetAllAsync();
        Assert.Equal(collection.ResultOperation.First().Id, getDto.ResultOperation.Id);

        var delete = await decorRepos.DeleteEntryAsync(getDto.ResultOperation.Id);
        Assert.True(delete.ResultOperation);
        collection = await decorRepos.GetAllAsync();
        Assert.Empty(collection.ResultOperation);

        _ = await decorRepos.ClearTableAsync();
    }

    [Fact]
    [PriorityTest(1)]
    public async void StuffingRepositories_Success_Test()
    {
        var stuffingRepositories = _serviceProvider.GetService<IStuffingRepositories>()!;
        _ = await stuffingRepositories.ClearTableAsync();

        StuffingDto? expectedDecorDto = new("Test2", 500);
        var decorDto = await stuffingRepositories.AddEntryAsync(expectedDecorDto);
        Assert.True(decorDto.ResultOperation != default);

        StuffingDto? updateDecorDto = new(decorDto.ResultOperation, "Форбс", 300);
        decorDto = await stuffingRepositories.UpdateEntryAsync(updateDecorDto);

        var findDto = await stuffingRepositories.GetByNameAsync("Форбс");
        Assert.NotNull(findDto.ResultOperation);
        Assert.Equal(decorDto.ResultOperation, findDto.ResultOperation!.Id);

        var getDto = await stuffingRepositories.GetByIdAsync(findDto.ResultOperation.Id);
        Assert.Equal(getDto.ResultOperation.Name, findDto.ResultOperation.Name);
        Assert.Equal(getDto.ResultOperation.Price, findDto.ResultOperation.Price);

        Result<IEnumerable<StuffingDto>>? collection = await stuffingRepositories.GetAllAsync();
        Assert.Equal(collection.ResultOperation.First().Id, getDto.ResultOperation.Id);

        var delete = await stuffingRepositories.DeleteEntryAsync(getDto.ResultOperation.Id);
        Assert.True(delete.ResultOperation);
        collection = await stuffingRepositories.GetAllAsync();
        Assert.Empty(collection.ResultOperation);

        _ = await stuffingRepositories.ClearTableAsync();
    }

    [Fact]
    [PriorityTest(2)]
    public async void ShortcakeRepositories_Success_Test()
    {
        var shortcakeRepositories = _serviceProvider.GetService<IShortcakeRepositories>()!;
        _ = await shortcakeRepositories.ClearTableAsync();

        ShortcakeDto? shortcakeDto = new("Test2", 500);
        var entryAsync = await shortcakeRepositories.AddEntryAsync(shortcakeDto);
        Assert.True(entryAsync.ResultOperation != default);

        ShortcakeDto? updateDecorDto = new(entryAsync.ResultOperation, "Форбс", 300);
        entryAsync = await shortcakeRepositories.UpdateEntryAsync(updateDecorDto);

        var findDto = await shortcakeRepositories.GetByNameAsync("Форбс");
        Assert.NotNull(findDto.ResultOperation);
        Assert.Equal(entryAsync.ResultOperation, findDto.ResultOperation!.Id);

        var getDto = await shortcakeRepositories.GetByIdAsync(findDto.ResultOperation.Id);
        Assert.Equal(getDto.ResultOperation.Name, findDto.ResultOperation.Name);
        Assert.Equal(getDto.ResultOperation.Price, findDto.ResultOperation.Price);

        Result<IEnumerable<ShortcakeDto>>? collection = await shortcakeRepositories.GetAllAsync();
        Assert.Equal(collection.ResultOperation.First().Id, getDto.ResultOperation.Id);

        var delete = await shortcakeRepositories.DeleteEntryAsync(getDto.ResultOperation.Id);
        Assert.True(delete.ResultOperation);
        collection = await shortcakeRepositories.GetAllAsync();
        Assert.Empty(collection.ResultOperation);

        _ = await shortcakeRepositories.ClearTableAsync();
    }

    [Fact]
    [PriorityTest(3)]
    public async void RoleRepositories_Success_Test()
    {
        var shortcakeRepositories = _serviceProvider.GetService<IAppUserRepositories>()!;
        _ = await shortcakeRepositories.ClearTableAsync();

        RoleUserDto? shortcakeDto = new("Директор");
        var entryAsync = await shortcakeRepositories.AddEntryAsync(shortcakeDto);
        Assert.True(entryAsync.ResultOperation != default);

        RoleUserDto? updateDecorDto = new(entryAsync.ResultOperation, "Князь");
        entryAsync = await shortcakeRepositories.UpdateEntryAsync(updateDecorDto);

        var findDto = await shortcakeRepositories.GetByRoleAsync("Князь");
        Assert.NotNull(findDto.ResultOperation);
        Assert.Equal(entryAsync.ResultOperation, findDto.ResultOperation!.Id);

        var getDto = await shortcakeRepositories.GetByIdAsync(findDto.ResultOperation.Id);
        Assert.Equal(getDto.ResultOperation.Id, findDto.ResultOperation.Id);
        Assert.Equal(getDto.ResultOperation.UserRole, findDto.ResultOperation.UserRole);

        Result<IEnumerable<RoleUserDto>>? collection = await shortcakeRepositories.GetAllAsync();
        Assert.Equal(collection.ResultOperation.First().Id, getDto.ResultOperation.Id);

        var delete = await shortcakeRepositories.DeleteEntryAsync(getDto.ResultOperation.Id);
        Assert.True(delete.ResultOperation);
        collection = await shortcakeRepositories.GetAllAsync();
        Assert.Empty(collection.ResultOperation);

        _ = await shortcakeRepositories.ClearTableAsync();
    }

    ~RepositoriesTest()
    {
        _ = _dbContext!.DisposeAsync();
    }
}