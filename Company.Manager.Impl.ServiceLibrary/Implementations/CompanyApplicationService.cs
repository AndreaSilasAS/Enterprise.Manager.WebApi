using Company.Manager.Contracts.ServiceLibrary.Contracts;
using Company.Manager.Contracts.ServiceLibrary.DTO;

namespace Company.Manager.Impl.ServiceLibrary.Implementations
{
    public class CompanyApplicationService : ICompanyApplicationService
    {
        private readonly ICompanyDomainService _companyDomainService;

        public CompanyApplicationService(ICompanyDomainService companyDomainService)
        {
            this._companyDomainService = companyDomainService;
        }
        public int CreateCompany(CreateCompanyRequest createCompanyRequest)
        {
            if (!IsValidIsin(createCompanyRequest.Isin))
            {
                throw new ArgumentException("Invalid ISIN provided");
            }
            var mapped = createCompanyRequest.ToEntity();

            return _companyDomainService.InsertCategory(mapped);
        }

        public IEnumerable<CompanyResponse> GetCompanies()
        {
            var companies = _companyDomainService.GetCategories()?.ToList();

            return _mapper.MapCollection<Library.Entities.Company, Company>(companies);
        }

        private static bool IsValidIsin(string isin)
        {
            return isin.Length == 12 && char.IsLetter(isin[0]) && char.IsLetter(isin[1]);
        }
    }
}
