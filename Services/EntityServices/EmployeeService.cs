using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts.EntityIService;

namespace Services.EntityServices
{
    internal sealed class EmployeeService:IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) 
        {
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public  IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            try
            {
                var Employees = _repositoryManager.EmployeeRepository.GetAllEmployees(trackChanges);
                return Employees;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($" Something went wrong in the name of {GetAllEmployees} service method : {ex} ");
                throw;
            }
        }
    }
}
