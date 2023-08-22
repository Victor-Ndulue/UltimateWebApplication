using AutoMapper;
using Contracts;
using Entities.Exceptions;
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
            _loggerManager.LogInfo("trying to get all companies");
            var companies =_repositoryManager.CompanyRepository.GetAllCompany(trackChanges);
            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            _loggerManager.LogInfo(" Comapnies data successfully retrieved from database .Attempting to return data");
           return companiesToReturn;          
        }

        public CompanyDto GetCompanyById(Guid id, bool trackChanges)
        {
            var company = _repositoryManager.CompanyRepository.GetCompany(id, trackChanges);
            if (company == null) { throw new CompanyNotFoundException(id); }
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }
    }
}
