using Enterprise.Manager.Library.Contracts;
using Enterprise.Manager.Library.Entities;
using Enterprise.Manager.Library.Exceptions;
using Enterprise.Manager.Library.InfraestructureContracts.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace Enterprise.Manager.Library.Implementations
{
    public class EnterpriseDomainService : IEnterpriseDomainService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<EnterpriseDomainService> _logger;

        public EnterpriseDomainService(ICompanyRepository companyRepository, ILogger<EnterpriseDomainService> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CompanyEntity>> GetCompaniesAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<CompanyEntity> GetCompanyAsync(int companyId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            if (company == null)
            {
                _logger.LogError("Company not found with company Id: " + companyId);
                throw new CompanyNotFoundException(companyId);
            }
            return company;
        }

        public async Task<CompanyEntity> GetCompanyAsync(string isin)
        {
            var company = await _companyRepository.GetByIsinAsync(isin);
            if (company == null)
            {
                _logger.LogError("Company not found with company ISIN: " + isin);
                throw new CompanyNotFoundException(isin);
            }
            return company;
        }

        public async Task InsertCompanyAsync(CompanyEntity company)
        {
            ValidateIsin(company.Isin);
            var companyDb = await _companyRepository.GetByIsinAsync(company.Isin);

            if (companyDb != null)
            {
                throw new DuplicateIsinException(company.Isin);
            }

            try
            {
                await _companyRepository.AddAsync(company);
            }
            catch (Exception ex)
            {
                _logger.LogError("InsertCompany : " + company.Name + " " + ex.Message);
                throw new CompanyInsertException(company.Name, ex);
            }
        }

        public async Task UpdateCompanyAsync(CompanyEntity company)
        {
            ValidateIsin(company.Isin);
            var companyDb = await _companyRepository.GetByIsinAsync(company.Isin);

            if (companyDb != null && companyDb.Id != company.Id)
            {
                throw new DuplicateIsinException(company.Isin);
            }

            try
            {
                await _companyRepository.UpdateAsync(company);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateCompany : " + company.Name + " " + ex.Message);
                throw new CompanyUpdateException(company.Name, ex);
            }
        }

        private void ValidateIsin(string isin)
        {
            if(string.IsNullOrEmpty(isin) && !char.IsLetter(isin[0]) && !char.IsLetter(isin[1]))
            {
                throw new InvalidIsinException(isin);
            }
        }
    }
}
