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
            



            await decorRepos.ClearTableAsync();
        }
    }
}