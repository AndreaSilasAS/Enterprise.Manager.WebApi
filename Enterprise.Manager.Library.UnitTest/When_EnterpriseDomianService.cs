using Enterprise.Manager.Library.Entities;
using Enterprise.Manager.Library.Exceptions;
using Enterprise.Manager.Library.Implementations;
using Enterprise.Manager.Library.InfraestructureContracts.UnitOfWork;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Enterprise.Manager.Library.UnitTest
{
    public class When_EnterpriseDomianService
    {
        private readonly Mock<ICompanyRepository> _companyRepositoryMock;
        private readonly Mock<ILogger<EnterpriseDomainService>> _loggerMock;
        private readonly EnterpriseDomainService _enterpriseDomainService;

        public When_EnterpriseDomianService()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _loggerMock = new Mock<ILogger<EnterpriseDomainService>>();
            _enterpriseDomainService = new EnterpriseDomainService(_companyRepositoryMock.Object, _loggerMock.Object);
        }
        [Fact]
        public async Task GetCompaniesAsync_ReturnsCompanies_WhenDataIsValid()
        {
            // Arrange
            var companiesFromRepository = GeEntityCompanies();


            _companyRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(companiesFromRepository);

            // Act
            var result = await _enterpriseDomainService.GetCompaniesAsync();

            // Assert
            Assert.Equal(companiesFromRepository.Count, result.Count());
            Assert.Equal(companiesFromRepository.First().Name, result.First().Name);
        }

        [Fact]
        public async Task InsertCompanyAsync_InsertsCompany_WhenValidData()
        {
            // Arrange
            var newCompany = GeEntityCompanies()[0];

            _companyRepositoryMock.Setup(repo => repo.GetByIsinAsync(It.IsAny<string>()))
                .ReturnsAsync((CompanyEntity)null); 

            _companyRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<CompanyEntity>()))
                .Returns(Task.CompletedTask); 

            // Act
            await _enterpriseDomainService.InsertCompanyAsync(newCompany);

            // Assert
            _companyRepositoryMock.Verify(repo => repo.AddAsync(newCompany), Times.Once); 
        }

        [Fact]
        public async Task InsertCompanyAsync_ThrowsDuplicateIsinException_WhenIsinExists()
        {
            // Arrange
            var newCompany = GeEntityCompanies()[0];

            var existingCompany = GeEntityCompanies()[1];

            _companyRepositoryMock.Setup(repo => repo.GetByIsinAsync(It.IsAny<string>()))
                .ReturnsAsync(existingCompany);

            // Act & Assert
            await Assert.ThrowsAsync<DuplicateIsinException>(async () =>
                await _enterpriseDomainService.InsertCompanyAsync(newCompany)
            );
        }

        [Fact]
        public async Task UpdateCompanyAsync_UpdatesCompany_WhenValidData()
        {
            // Arrange
            var companyToUpdate = GeEntityCompanies()[0];

            _companyRepositoryMock.Setup(repo => repo.GetByIsinAsync(It.IsAny<string>()))
                .ReturnsAsync((CompanyEntity)null); 

            _companyRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<CompanyEntity>()))
                .Returns(Task.CompletedTask);

            // Act
            await _enterpriseDomainService.UpdateCompanyAsync(companyToUpdate);

            // Assert
            _companyRepositoryMock.Verify(repo => repo.UpdateAsync(companyToUpdate), Times.Once); 
        }

        [Fact]
        public async Task UpdateCompanyAsync_ThrowsDuplicateIsinException_WhenIsinExists()
        {
            // Arrange
            var companyToUpdate = GeEntityCompanies()[0];

            var existingCompany = GeEntityCompanies()[1];

            _companyRepositoryMock.Setup(repo => repo.GetByIsinAsync(It.IsAny<string>()))
                .ReturnsAsync(existingCompany); 

            // Act & Assert
            await Assert.ThrowsAsync<DuplicateIsinException>(async () =>
            await _enterpriseDomainService.UpdateCompanyAsync(companyToUpdate)
            );
        }

        private List<CompanyEntity> GeEntityCompanies()
        {
            return new List<CompanyEntity>
            {
                new CompanyEntity { Id = 1, Name = "Comapny A", Exchange = "NYSE", Ticker = "A", Isin = "US123456789", Website = "http://companyA.com" },
                new CompanyEntity { Id = 2, Name = "Company B", Exchange = "NASDAQ", Ticker = "B", Isin = "US123456789", Website = "http://companyB.com" },
                new CompanyEntity { Id = 3, Name = "Company C", Exchange = "NASDDV", Ticker = "C", Isin = "US12345124", Website = "http://companyC.com" }
            };
        }
    }
}
