using Data.Dto;
using Data.Resositoryes;
using Xunit;

namespace UnitTests
{
    public class RepositoryEmployeeTests
    {
        private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

        [Fact]
        public void Add_Employee_Test()
        {
            var repository = new EmployeeRepos(ConnectionString);

            
        }
    }
}