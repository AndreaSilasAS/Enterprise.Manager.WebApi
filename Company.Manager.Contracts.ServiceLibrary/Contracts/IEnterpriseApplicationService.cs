using Enterprise.Manager.Contracts.ServiceLibrary.DTO;
using Enterprise.Manager.Extensions;

namespace Enterprise.Manager.Contracts.ServiceLibrary.Contracts
{
    public interface IEnterpriseApplicationService
    {
        Task<OperationResult<IEnumerable<CompanyDto>>> GetAllCompanies();
        Task<OperationResult<CompanyDto>> GetCompany(int companyId);
        Task<OperationResult<CompanyDto>> GetCompany(string isin);
        Task<OperationResult> CreateCompany(CompanyDto createCompanyRequest);
        Task<OperationResult> UpdateCompany(CompanyDto createCompanyRequest);
    }
}
