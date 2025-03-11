using Enterprise.Manager.Library.Entities;

namespace Enterprise.Manager.Library.Contracts
{
    public  interface IEnterpriseDomainService
    {
        Task<IEnumerable<CompanyEntity>> GetCompaniesAsync();
        Task<CompanyEntity> GetCompanyAsync(int companyId);
        Task<CompanyEntity> GetCompanyAsync(string isin);
        Task InsertCompanyAsync(CompanyEntity company);
        Task UpdateCompanyAsync(CompanyEntity company);
    }
}
