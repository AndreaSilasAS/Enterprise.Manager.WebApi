using AutoMapper;
using Enterprise.Manager.Contracts.ServiceLibrary.DTO;
using Enterprise.Manager.Contracts.ServiceLibrary.Implementations;
using Enterprise.Manager.Extensions;
using Enterprise.Manager.Library.Contracts;
using Enterprise.Manager.Library.Entities;
using Moq;
using Xunit;

namespace Enterprise.Manager.ServiceLibrary.UnitTest
{
    public class When_EnterpriseApplicationService
    {
        private readonly Mock<IEnterpriseDomainService> _enterpriseDomainServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EnterpriseApplicationService _enterpriseApplicationService;

        public When_EnterpriseApplicationService()
        {
            _enterpriseDomainServiceMock = new Mock<IEnterpriseDomainService>();
            _mapperMock = new Mock<IMapper>();
            _enterpriseApplicationService = new EnterpriseApplicationService(_enterpriseDomainServiceMock.Object, _mapperMock.Object);

        }
        [Fact]
        public async Task GetAllCompanies_ReturnAllCompanies()
        {
            //ARRANGE
            var companiesFromService = GetEntityCompanies();

            var expectedResponse = GetTestCompanies();

            _enterpriseDomainServiceMock.Setup(service => service.GetCompaniesAsync())
                .ReturnsAsync(companiesFromService);

            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CompanyDto>>(It.IsAny<IEnumerable<CompanyEntity>>()))
                .Returns(expectedResponse);

            //ACT
            var result = await _enterpriseApplicationService.GetAllCompanies();

            //ASSERT
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Count(), result.Result.Count());
            Assert.Equal(expectedResponse.First().Name, result.Result.First().Name);
        }

        [Fact]
        public async Task GetCompany_ById_ReturnsCompany_WhenDataIsValid()
        {
            // ARRANGE
            var companyFromService = GetEntityCompanies()[0];

            var expectedResponse = GetTestCompanies()[0];

            _enterpriseDomainServiceMock.Setup(service => service.GetCompanyAsync(It.IsAny<int>()))
                .ReturnsAsync(companyFromService);

            _mapperMock.Setup(mapper => mapper.Map<CompanyDto>(It.IsAny<CompanyEntity>()))
                .Returns(expectedResponse);

            // ACT
            var result = await _enterpriseApplicationService.GetCompany(1);

            // ASSERT
            Assert.NotNull(result);  
            Assert.Equal(expectedResponse.Name, result.Result.Name);
        }

        [Fact]
        public async Task UpdateCompany_ReturnsSuccess_WhenDataIsValid()
        {
            // ARRANGE
            var updateRequest = GetTestCompanies()[0];

            _enterpriseDomainServiceMock.Setup(service => service.UpdateCompanyAsync(It.IsAny<CompanyEntity>()))
                .Returns(Task.CompletedTask);  

            // ACT
            var result = await _enterpriseApplicationService.UpdateCompany(updateRequest);

            // ASSERT
            Assert.IsType<OperationResult<CompanyDto>>(result);
            Assert.False(result.HasErrors);
        }

        private List<CompanyDto> GetTestCompanies()
        {
            return new List<CompanyDto>
            {
                new CompanyDto { Name = "Company A", Exchange = "NYSE", Ticker = "A", Isin = "US123", Website = "http://companyA.com" },
                new CompanyDto { Name = "Company B", Exchange = "NASDAQ", Ticker = "B", Isin = "US456", Website = "http://companyB.com" }
            };
        }

        private List<CompanyEntity> GetEntityCompanies()
        {
            return new List<CompanyEntity>
            {
                new CompanyEntity { Id = 1, Name = "Company A", Exchange = "NYSE", Ticker = "A", Isin = "US123", Website = "http://companyA.com" },
                new CompanyEntity { Id = 2, Name = "Company B", Exchange = "NASDAQ", Ticker = "B", Isin = "US456", Website = "http://companyB.com" }
            };
        }
    }
}