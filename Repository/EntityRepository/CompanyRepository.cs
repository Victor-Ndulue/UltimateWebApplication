using Contracts.EntityContracts;
using Entities.Models;

namespace Repository.EntityRepository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Company GetCompany(Guid companyId, bool trackChanges)
        {
            Company company = FindByCondition(id => id.Id == companyId, trackChanges).SingleOrDefault();
            return company;
        }

        public IEnumerable<Company> GetAllCompany(bool trackChanges)
        {
            return FindAllAsync(trackChanges)
                .OrderBy(x=>x.Name).ToList();
        }
    }
}
