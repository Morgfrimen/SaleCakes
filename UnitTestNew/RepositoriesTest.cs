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
        private IServiceProvider _serviceProvide;

        public RepositoriesTest(Startup fixture)
        {
            _serviceProvide = fixture.ServiceProvider;
        }

        [Fact, PriorityTest(1)]
        public async void DecorRepositories_Success_Test()
        {
            using var dbContext = _serviceProvide.GetService<SaleCakesDbContext>();
            var decorRepos = _serviceProvide.GetService<IDecorRepositories>()!;
            await decorRepos.ClearTableAsync();

            var expectedDecorDto = new DecorDto("Test2",500);
            var decorDto = await decorRepos.AddEntryAsync(expectedDecorDto);
            Assert.True(decorDto.ResultOperation != default);

            var updateDecorDto = new DecorDto(decorDto.ResultOperation, "Форбс", 300);
            decorDto = await decorRepos.UpdateEntryAsync(updateDecorDto);

            var findDto = await decorRepos.GetByNameAsync("Форбс");
            Assert.NotNull(findDto.ResultOperation);
            Assert.Equal(decorDto.ResultOperation,findDto.ResultOperation!.Id);

            var getDto = await decorRepos.GetByIdAsync(findDto.ResultOperation.Id);
            Assert.Equal(getDto.ResultOperation.Name, findDto.ResultOperation.Name);
            Assert.Equal(getDto.ResultOperation.Price, findDto.ResultOperation.Price);

            var collection = await decorRepos.GetAllAsync();
            Assert.Equal(collection.ResultOperation.First().Id,getDto.ResultOperation.Id);

            var delete = await decorRepos.DeleteEntryAsync(getDto.ResultOperation.Id);
            Assert.True(delete.ResultOperation);
            collection = await decorRepos.GetAllAsync();
            Assert.Equal(0,collection.ResultOperation.Count());

            await decorRepos.ClearTableAsync();
        }
    }
}