using System.Linq;
using Data.Legacy.Dto;
using Data.Legacy.Resositoryes;
using Xunit;

namespace UnitTests;

public class RepositoryShortcakeTests
{
    private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    [Fact]
    public async void Shortcake_Test()
    {
        var name = "яблочное";
        var price = 240m;
        var repository = new ShortcakeRepos(ConnectionString);
        var stuffingDto = new ShortcakeDto(name, price);

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

        var updateShortcaketoDto = collection.FirstOrDefault(item => item.Name == name);
        updateShortcaketoDto = new ShortcakeDto(updateShortcaketoDto!.Id, name, price + 10);
        Assert.True(await repository.UpdateAsync(updateShortcaketoDto));

        var getDto = await repository.GetByIdAsync(updateShortcaketoDto.Id);

        Assert.Equal(getDto.Id, updateShortcaketoDto.Id);

        Assert.True(await repository.DeleteAsync(updateShortcaketoDto.Id));

        collection = await repository.GetAllAsync();
        if (collection is null)
            return;
        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));
    }
}