using AutoMapper;
using Contracts;
using Service.Contracts.CommonIService;
using Service.Contracts.EntityIService;
using Services.EntityServices;

namespace Services.CommonServices
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper)
        {
            _companyService = new Lazy<ICompanyService>(() => new
            CompanyService(logger, repositoryManager, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new
            EmployeeService(repositoryManager, logger, mapper));
        }
        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}