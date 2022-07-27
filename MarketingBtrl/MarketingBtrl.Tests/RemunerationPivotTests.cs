using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingBtrl.Services;
using MarketingBtrl.Tests.Infrastructure;
using Xunit;

namespace MarketingBtrl.Tests
{
    [Collection("remuneration pivot collection")]
    public class RemunerationPivotTests
    {
        readonly RemunerationPivotContextFixture _repositoryContextFixture;
        readonly RemunerationService _remunerationService;

        public RemunerationPivotTests(RemunerationPivotContextFixture repositoryContextFixture)
        {
            _repositoryContextFixture = repositoryContextFixture;
            var _configuration = new Mock<IConfiguration>();
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "ConnectionString")]).Returns("mock value");

            _remunerationService = new RemunerationService(repositoryContextFixture.RepositoryContext, _configuration.Object);
        }

        [Fact]
        public async Task Make_Sure_Pivot_Is_Working_Properly()
        {
            //arrange
            int year = 2020;
            int month = 3;

            //act
            var result = await _remunerationService.GetRemunerationsPivotAsync(year, month);



            //assert
            Assert.Equal(4, result.Length);
            Assert.Equal(4, result[0].Length);

            Assert.Equal(1, result[3][0]);
            Assert.Equal(1, result[3][1]);
            Assert.Equal(1, result[3][2]);
            Assert.Equal(1, result[3][3]);


            _repositoryContextFixture.Reset();
        }


        [Fact]
        public async Task Get_Statistics()
        {
            //arrange
            int year = 2020;
            int month = 3;

            //act
            var result = await _remunerationService.GetStatistics(year, month);



            //assert
            //Assert.Equal(4, result.Length);
            //Assert.Equal(4, result[0].Length);

            //Assert.Equal(1, result[3][0]);
            //Assert.Equal(1, result[3][1]);
            //Assert.Equal(1, result[3][2]);
            //Assert.Equal(1, result[3][3]);


            _repositoryContextFixture.Reset();
        }


    }
}
