using AutoMapper;
using Enterprise.Manager.Contracts.ServiceLibrary.Contracts;
using Enterprise.Manager.Contracts.ServiceLibrary.DTO;
using Enterprise.Manager.Extensions;
using Enterprise.Manager.Library.Contracts;
using Enterprise.Manager.ServiceLibrary.Mapper.Custom;

namespace Enterprise.Manager.Contracts.ServiceLibrary.Implementations
{
    public class EnterpriseApplicationService : IEnterpriseApplicationService
    {
        private readonly IEnterpriseDomainService _enterpriseDomainService;
        private readonly IMapper _mapper;

        public EnterpriseApplicationService(IEnterpriseDomainService enterpriseDomainService, IMapper mapper)
        {
            _enterpriseDomainService = enterpriseDomainService;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<CompanyDto>>> GetAllCompanies()
        {
            var companies = await _enterpriseDomainService.GetCompaniesAsync();

            return new OperationResult<IEnumerable<CompanyDto>>
            {
                Result = _mapper.Map<IEnumerable<CompanyDto>>(companies)
            };
        }

        public async Task<OperationResult> CreateCompany(CompanyDto createCompanyRequest)
        {
            var mapped = createCompanyRequest.FromCreateRequestToEntity();

            await _enterpriseDomainService.InsertCompanyAsync(mapped);


            return new OperationResult<CompanyDto> {};
        }

        public async Task<OperationResult<CompanyDto>> GetCompany(int companyId)
        {
            var company = await _enterpriseDomainService.GetCompanyAsync(companyId);

            return new OperationResult<CompanyDto>()
            {
                Result = _mapper.Map<CompanyDto>(company)
            };
        }

        public async Task<OperationResult<CompanyDto>> GetCompany(string isin)
        {
            var company = await _enterpriseDomainService.GetCompanyAsync(isin);

            return new OperationResult<CompanyDto>()
            {
                Result = _mapper.Map<CompanyDto>(company)
            };
        }

        public async Task<OperationResult> UpdateCompany(CompanyDto updateCompanyRequest)
        {
            var mapped = updateCompanyRequest.FromUpdateRequestToEntity();

            await _enterpriseDomainService.UpdateCompanyAsync(mapped);

            return new OperationResult<CompanyDto> { };
        }
    }
}
