using Enterprise.Manager.Contracts.ServiceLibrary.Contracts;
using Enterprise.Manager.Contracts.ServiceLibrary.DTO;
using Enterprise.Manager.Extensions;
using Enterprise.Manager.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Enterprise.Manager.WebApi.UnitTest
{
    public class When_EnterpriseController
    {
        private readonly Mock<IEnterpriseApplicationService> _enterpriseApplicationServiceMock;
        private readonly Mock<ILogger<EnterpriseController>> _loggerMock;
        private readonly EnterpriseController _enterpriseController;

        public When_EnterpriseController()
        {
            _enterpriseApplicationServiceMock = new Mock<IEnterpriseApplicationService>();
            _loggerMock = new Mock<ILogger<EnterpriseController>>();
            _enterpriseController = new EnterpriseController(_enterpriseApplicationServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAllCompanies_ReturnsOkResult_WithValidData()
        {
            // Arrange
            var companies = GetTestCompanies();

            _enterpriseApplicationServiceMock.Setup(service => service.GetAllCompanies())
                .ReturnsAsync(new OperationResult<IEnumerable<CompanyDto>> { Result = companies });

            // Act
            var result = await _enterpriseController.GetAllCompanies();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllCompanies_ReturnsError_WithInvalidData()
        {
            // Arrange
            _enterpriseApplicationServiceMock.Setup(service => service.GetAllCompanies())
                .ThrowsAsync(new Exception());

            // Act
            var result = await _enterpriseController.GetAllCompanies();

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Internal server error in GetAllCompanies", actionResult.Value);
        }

        [Fact]
        public async Task GetCompnayById_ReturnsOkResult_WithValidData()
        {
            // Arrange
            var companyId = 1;
            var company = GetTestCompanies()[0];

            _enterpriseApplicationServiceMock.Setup(service => service.GetCompany(It.IsAny<int>()))
                .ReturnsAsync(new OperationResult<CompanyDto> { Result = company });

            // Act
            var result = await _enterpriseController.GetCompanyById(companyId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetCompnayById_ReturnsError_WithInvalidData()
        {
            // Arranges
            var companyId = 5555;
            var company = GetTestCompanies()[0];

            _enterpriseApplicationServiceMock.Setup(service => service.GetCompany(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _enterpriseController.GetCompanyById(companyId);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Internal server error in GetCompanyById", actionResult.Value);
        }

        [Fact]
        public async Task GetCompnayByIsin_ReturnsOkResult_WithValidData()
        {
            // Arrange
            var isin = "US123";
            var company = GetTestCompanies()[0];

            _enterpriseApplicationServiceMock.Setup(service => service.GetCompany(It.IsAny<string>()))
                .ReturnsAsync(new OperationResult<CompanyDto> { Result = company });

            // Act
            var result = await _enterpriseController.GetCompanyByIsin(isin);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task GetCompnayByIsin_ReturnsError_WithInvalidData()
        {
            // Arrange
            var isin = "test";
            var company = GetTestCompanies()[0];

            _enterpriseApplicationServiceMock.Setup(service => service.GetCompany(It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _enterpriseController.GetCompanyByIsin(isin);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Internal server error in GetCompanyByIsin", actionResult.Value);
        }


        [Fact]
        public async Task CreateCompany_ReturnsOkResult_WithValidData()
        {
            // Arrange
            var company = GetTestCompanies()[0];

            _enterpriseApplicationServiceMock.Setup(service => service.CreateCompany(It.IsAny<CompanyDto>()))
                .ReturnsAsync(new OperationResult());

            // Act
            var result = await _enterpriseController.CreateCompany(company);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateCompany_ReturnsError_WithInvalidData()
        {
            // Arrange
            var company = new CompanyDto();

            _enterpriseApplicationServiceMock.Setup(service => service.CreateCompany(It.IsAny<CompanyDto>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _enterpriseController.CreateCompany(company);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Internal server error in CreateCompany", actionResult.Value);
        }

        [Fact]
        public async Task UpdateCompany_ReturnsOkResult_WithValidData()
        {
            // Arrange
            var company = GetTestCompanies()[0];

            _enterpriseApplicationServiceMock.Setup(service => service.UpdateCompany(It.IsAny<CompanyDto>()))
                .ReturnsAsync(new OperationResult());

            // Act
            var result = await _enterpriseController.UpdateCompany(company);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateCompany_ReturnsError_WithInvalidData()
        {
            // Arrange
            var company = new CompanyDto();

            _enterpriseApplicationServiceMock.Setup(service => service.UpdateCompany(It.IsAny<CompanyDto>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _enterpriseController.UpdateCompany(company);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Internal server error in UpdateCompany", actionResult.Value);
        }

        private List<CompanyDto> GetTestCompanies()
        {
            return new List<CompanyDto>
            {
                new CompanyDto { Name = "Comapny A", Exchange = "NYSE", Ticker = "A", Isin = "US123", Website = "http://companyA.com" },
                new CompanyDto { Name = "Company B", Exchange = "NASDAQ", Ticker = "B", Isin = "US4d6", Website = "http://companyB.com" }
            };
        }
    }
}
