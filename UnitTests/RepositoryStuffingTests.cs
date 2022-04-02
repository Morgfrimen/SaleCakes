using System.Linq;
using Data.Legacy.Dto;
using Data.Legacy.Resositoryes;
using Xunit;

namespace UnitTests;

public class RepositoryStuffingTests
{
    private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    [Fact]
    public async void Stuffing_Test()
    {
        var name = "яблочное";
        var price = 240m;
        var repository = new StuffingRepos(ConnectionString);
        var stuffingDto = new StuffingDto(name, price);

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
        updateStuffingDtoDto = new StuffingDto(updateStuffingDtoDto!.Id, name, price + 10);
        Assert.True(await repository.UpdateAsync(updateStuffingDtoDto));

        var getDto = await repository.GetByIdAsync(updateStuffingDtoDto.Id);

        Assert.Equal(getDto.Id, updateStuffingDtoDto.Id);

        Assert.True(await repository.DeleteAsync(updateStuffingDtoDto.Id));

        collection = await repository.GetAllAsync();

        if (collection is null)
        {
            return;
        }

        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));
    }
}