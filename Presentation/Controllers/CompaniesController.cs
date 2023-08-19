using Microsoft.AspNetCore.Mvc;
using Service.Contracts.CommonIService;

namespace Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController:ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController( IServiceManager service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetCompanies()
        {
            var comapnies = _service.CompanyService.GetAllCompanies(trackChanges: false);
            return Ok(comapnies);          
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetCompany(Guid id) 
        {
            var company = _service.CompanyService.GetCompanyById(id, trackChanges: false);
            return Ok(company);
        }
    }
}