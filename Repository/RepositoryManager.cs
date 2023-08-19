using Contracts;
using Contracts.EntityContracts;
using Repository.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _employeeRepository = new Lazy<IEmployeeRepository>(()=>new EmployeeRepository(repositoryContext));
            _companyRepository = new Lazy<ICompanyRepository>(()=>new CompanyRepository(repositoryContext));
        }

        public ICompanyRepository CompanyRepository => _companyRepository.Value;

        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
