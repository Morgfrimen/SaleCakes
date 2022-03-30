﻿using System.Linq;
using Data.Dto;
using Data.Resositoryes;
using Xunit;

namespace UnitTests;

public class RepositoryDecorTests
{
    private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    [Fact]
    public async void Decor_Test()
    {
        var name = "яблочное";
        var price = 240m;
        var repository = new DecorRepos(ConnectionString);
        var stuffingDto = new DecorDto(name, price);

        Assert.True(await repository.AddAsync(stuffingDto));

        var collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var deletedDro = collection.FirstOrDefault(item => item.Name == name);
        Assert.NotNull(deletedDro);

        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));

        Assert.True(await repository.AddAsync(stuffingDto));

        collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var updateStuffingDtoDto = collection.FirstOrDefault(item => item.Name == name);
        updateStuffingDtoDto = new DecorDto(updateStuffingDtoDto!.Id, name, price + 10);
        Assert.True(await repository.UpdateAsync(updateStuffingDtoDto));

        Assert.True(await repository.DeleteAsync(updateStuffingDtoDto.Id));
    }
}