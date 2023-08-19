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
            try
            {
                var Get = _service.CompanyService.GetAllCompanies(trackChanges: false);
                return Ok(Get);
            }
            catch 
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}