using System.Linq;
using System.Threading.Tasks;
using Data.Legacy.Dto;
using Data.Legacy.Resositoryes;
using Xunit;

namespace UnitTestsLegacy;

public class RepositoryTierTests
{
    private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    [Fact]
    public async void Tiers_Test()
    {
        var decor = await AddDecorDto();
        var stuffing = await AddStuffingDto();
        var shortcake = await AddShortcakeDto();

        var repository = new TiersRepos(ConnectionString);
        var tiersDto = new TiersDto(stuffing.Id, decor.Id, shortcake.Id);

        Assert.True(await repository.AddAsync(tiersDto));

        var collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var deletedDro = collection.FirstOrDefault(item => item.DecorId == decor.Id);
        Assert.NotNull(deletedDro);

        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));

        Assert.True(await repository.AddAsync(tiersDto));

        collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        var updateTiersDto = collection.FirstOrDefault(item => item.StuffingId == stuffing.Id);
        updateTiersDto = new TiersDto(updateTiersDto.Id, stuffing.Id, decor.Id, shortcake.Id);
        Assert.True(await repository.UpdateAsync(updateTiersDto));

        var getDto = await repository.GetByIdAsync(updateTiersDto.Id);

        Assert.Equal(getDto.Id, updateTiersDto.Id);

        Assert.True(await repository.DeleteAsync(updateTiersDto.Id));


        collection = await repository.GetAllAsync();

        if (collection is null)
        {
            return;
        }

        foreach (var dto in collection)
            Assert.True(await repository.DeleteAsync(dto.Id));
    }

    private async Task<StuffingDto> AddStuffingDto()
    {
        var name = "яблочноеStuffin";
        var price = 240m;
        var repository = new StuffingRepos(ConnectionString);
        var stuffingDto = new StuffingDto(name, price);

        Assert.True(await repository.AddAsync(stuffingDto));

        var collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        return collection!.FirstOrDefault(item => item.Name == name);
    }

    private async Task<DecorDto> AddDecorDto()
    {
        var name = "яблочноеDecor";
        var price = 240m;
        var repository = new DecorRepos(ConnectionString);
        var stuffingDto = new DecorDto(name, price);

        Assert.True(await repository.AddAsync(stuffingDto));

        var collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        return collection!.FirstOrDefault(item => item.Name == name);
    }

    private async Task<ShortcakeDto> AddShortcakeDto()
    {
        var name = "яблочноеShortca";
        var price = 240m;
        var repository = new ShortcakeRepos(ConnectionString);
        var stuffingDto = new ShortcakeDto(name, price);

        Assert.True(await repository.AddAsync(stuffingDto));

        var collection = await repository.GetAllAsync();
        Assert.NotNull(collection);

        return collection!.FirstOrDefault(item => item.Name == name);
    }
}