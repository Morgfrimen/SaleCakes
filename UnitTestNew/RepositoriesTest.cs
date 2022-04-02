using Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Data.Dto;
using Data.Repositories.Abstract;
using UnitTestNew.TestSettings;
using Xunit;

namespace UnitTestNew
{
    [TestCaseOrderer("UnitTestNew.TestSettings.PriorityOrderer", "UnitTestNew")]
    public class RepositoriesTest: IClassFixture<Startup>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SaleCakesDbContext? _dbContext;

        public RepositoriesTest(Startup fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _dbContext = _serviceProvider!.GetService<SaleCakesDbContext>();
        }

        [Fact, PriorityTest(0)]
        public async void DecorRepositories_Success_Test()
        {
            var decorRepos = _serviceProvider.GetService<IDecorRepositories>()!;
            await decorRepos.ClearTableAsync();

            var expectedDecorDto = new DecorDto("Test2",500);
            var entryAsync = await decorRepos.AddEntryAsync(expectedDecorDto);
            Assert.True(entryAsync.ResultOperation != default);

            var updateDecorDto = new DecorDto(entryAsync.ResultOperation, "Форбс", 300);
            entryAsync = await decorRepos.UpdateEntryAsync(updateDecorDto);

            var findDto = await decorRepos.GetByNameAsync("Форбс");
            Assert.NotNull(findDto.ResultOperation);
            Assert.Equal(entryAsync.ResultOperation,findDto.ResultOperation!.Id);

            var getDto = await decorRepos.GetByIdAsync(findDto.ResultOperation.Id);
            Assert.Equal(getDto.ResultOperation.Name, findDto.ResultOperation.Name);
            Assert.Equal(getDto.ResultOperation.Price, findDto.ResultOperation.Price);

            var collection = await decorRepos.GetAllAsync();
            Assert.Equal(collection.ResultOperation.First().Id,getDto.ResultOperation.Id);

            var delete = await decorRepos.DeleteEntryAsync(getDto.ResultOperation.Id);
            Assert.True(delete.ResultOperation);
            collection = await decorRepos.GetAllAsync();
            Assert.Empty(collection.ResultOperation);

            await decorRepos.ClearTableAsync();
        }

        [Fact, PriorityTest(1)]
        public async void StuffingRepositories_Success_Test()
        {
            var stuffingRepositories = _serviceProvider.GetService<IStuffingRepositories>()!;
            await stuffingRepositories.ClearTableAsync();

            var expectedDecorDto = new StuffingDto("Test2", 500);
            var decorDto = await stuffingRepositories.AddEntryAsync(expectedDecorDto);
            Assert.True(decorDto.ResultOperation != default);

            var updateDecorDto = new StuffingDto(decorDto.ResultOperation, "Форбс", 300);
            decorDto = await stuffingRepositories.UpdateEntryAsync(updateDecorDto);

            var findDto = await stuffingRepositories.GetByNameAsync("Форбс");
            Assert.NotNull(findDto.ResultOperation);
            Assert.Equal(decorDto.ResultOperation, findDto.ResultOperation!.Id);

            var getDto = await stuffingRepositories.GetByIdAsync(findDto.ResultOperation.Id);
            Assert.Equal(getDto.ResultOperation.Name, findDto.ResultOperation.Name);
            Assert.Equal(getDto.ResultOperation.Price, findDto.ResultOperation.Price);

            var collection = await stuffingRepositories.GetAllAsync();
            Assert.Equal(collection.ResultOperation.First().Id, getDto.ResultOperation.Id);

            var delete = await stuffingRepositories.DeleteEntryAsync(getDto.ResultOperation.Id);
            Assert.True(delete.ResultOperation);
            collection = await stuffingRepositories.GetAllAsync();
            Assert.Empty(collection.ResultOperation);

            await stuffingRepositories.ClearTableAsync();
        }

        [Fact, PriorityTest(2)]
        public async void ShortcakeRepositories_Success_Test()
        {
            var shortcakeRepositories = _serviceProvider.GetService<IShortcakeRepositories>()!;
            await shortcakeRepositories.ClearTableAsync();

            var shortcakeDto = new ShortcakeDto("Test2", 500);
            var entryAsync = await shortcakeRepositories.AddEntryAsync(shortcakeDto);
            Assert.True(entryAsync.ResultOperation != default);

            var updateDecorDto = new ShortcakeDto(entryAsync.ResultOperation, "Форбс", 300);
            entryAsync = await shortcakeRepositories.UpdateEntryAsync(updateDecorDto);

            var findDto = await shortcakeRepositories.GetByNameAsync("Форбс");
            Assert.NotNull(findDto.ResultOperation);
            Assert.Equal(entryAsync.ResultOperation, findDto.ResultOperation!.Id);

            var getDto = await shortcakeRepositories.GetByIdAsync(findDto.ResultOperation.Id);
            Assert.Equal(getDto.ResultOperation.Name, findDto.ResultOperation.Name);
            Assert.Equal(getDto.ResultOperation.Price, findDto.ResultOperation.Price);

            var collection = await shortcakeRepositories.GetAllAsync();
            Assert.Equal(collection.ResultOperation.First().Id, getDto.ResultOperation.Id);

            var delete = await shortcakeRepositories.DeleteEntryAsync(getDto.ResultOperation.Id);
            Assert.True(delete.ResultOperation);
            collection = await shortcakeRepositories.GetAllAsync();
            Assert.Empty(collection.ResultOperation);

            await shortcakeRepositories.ClearTableAsync();
        }

        ~RepositoriesTest()
        {
            _dbContext!.DisposeAsync();
        }
    }
}