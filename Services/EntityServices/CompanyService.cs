using AutoMapper;
using Contracts;
using Service.Contracts.EntityIService;
using Shared.DTO_s;

namespace Services.EntityServices
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IRepositoryManager  _repositoryManager;
        private readonly IMapper _mapper;
        public CompanyService( ILoggerManager loggerManager,IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            try
            {
                _loggerManager.LogInfo("trying to get all companies");
                var companies =_repositoryManager.CompanyRepository.GetAllCompany(trackChanges);
                var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                _loggerManager.LogInfo(" Comapnies data successfully retrieved from database .Attempting to return data");
                return companiesToReturn;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the name of {GetAllCompanies} service method { ex} ");              
                throw;
            }
               
        }
    }
}
