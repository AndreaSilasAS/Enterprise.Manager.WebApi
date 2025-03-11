using Enterprise.Manager.Contracts.ServiceLibrary.Contracts;
using Enterprise.Manager.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Enterprise.Manager.WebApi.Controllers
{
    /// <summary>
    /// Endpoints to manage enterprise from external resources
    /// </summary>
    [ApiController]
    [Route("api/enterprise")]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseApplicationService _enterpriseApplicationService;
        private readonly ILogger<EnterpriseController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="enterpriseApplicationService">Enterprise Application Service</param>
        public EnterpriseController(IEnterpriseApplicationService enterpriseApplicationService, ILogger<EnterpriseController> logger)
        {
            _enterpriseApplicationService = enterpriseApplicationService;
            _logger = logger;
        }


        ///<summary>Get all companies</summary>
        ///<response code="500">Internal server error</response>
        ///<response code="200">OK</response>
        ///<response code="400">Bad Request</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyDto>), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                _logger.LogInformation("[{0}][{1}] Begin action.", GetType().Name, MethodBase.GetCurrentMethod().Name);
                var result = await _enterpriseApplicationService.GetAllCompanies();

                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] " +
                                 $"Ex: {ex} ");
                return StatusCode(500, "Internal server error in GetAllCompanies");
            }
        }

        ///<summary>Get company by Id</summary>
        ///<response code="500">Internal server error</response>
        ///<response code="200">OK</response>
        ///<response code="400">Bad Request</response>
        ///
        [HttpGet]
        [Route("{companyId}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDto>), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCompanyById(int companyId)
        {
            try
            {
                _logger.LogInformation("[{0}][{1}] Begin action.", GetType().Name, MethodBase.GetCurrentMethod().Name);
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Model error: {ModelState}");
                    return BadRequest(ModelState);
                }
                var result = await _enterpriseApplicationService.GetCompany(companyId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] " +
                                 $"Ex: {ex} ");
                return StatusCode(500, "Internal server error in GetCompanyById");
            }
        }

        ///<summary>Get company by ISIN</summary>
        ///<response code="500">Internal server error</response>
        ///<response code="200">OK</response>
        ///<response code="400">Bad Request</response>
        ///
        [HttpGet]
        [Route("isin/{isin}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDto>), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]  
        public async Task<IActionResult> GetCompanyByIsin(string isin)
        {
            try
            {
                _logger.LogInformation("[{0}][{1}] Begin action.", GetType().Name, MethodBase.GetCurrentMethod().Name);
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Model error: {ModelState}");
                    return BadRequest(ModelState);
                }
                var result = await _enterpriseApplicationService.GetCompany(isin);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] " +
                                 $"Ex: {ex} ");
                return StatusCode(500, "Internal server error in GetCompanyByIsin");
            }
        }

        ///<summary>Create new Company</summary>
        ///<response code="500">Internal server error</response>
        ///<response code="200">OK</response>
        ///<response code="400">Bad Request</response>
        ///
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto company)
        {
            try
            {
                _logger.LogInformation("[{0}][{1}] Begin action.", GetType().Name, MethodBase.GetCurrentMethod().Name);
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Model error: {ModelState}");
                    return BadRequest(ModelState);
                }

                var result = await _enterpriseApplicationService.CreateCompany(company);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] " +
                                 $"Ex: {ex} ");
                return StatusCode(500, "Internal server error in CreateCompany");
            }
        }

        ///<summary>Update Company</summary>
        ///<response code="500">Internal server error</response>
        ///<response code="200">OK</response>
        ///<response code="400">Bad Request</response>
        ///
        [HttpPost]
        [Route("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyDto company)
        {
            try
            {
                _logger.LogInformation("[{0}][{1}] Begin action.", GetType().Name, MethodBase.GetCurrentMethod().Name);
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Model error: {ModelState}");
                    return BadRequest(ModelState);
                }

                var result = await _enterpriseApplicationService.UpdateCompany(company);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] " +
                                 $"Ex: {ex} ");
                return StatusCode(500, "Internal server error in UpdateCompany");
            }
        }
    }
}
