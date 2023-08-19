using Contracts.EntityContracts;
using Entities.Models;

namespace Repository.EntityRepository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        

        public IEnumerable<Company> GetAllCompany(bool trackChanges)
        {
            return FindAllAsync(trackChanges)
                .OrderBy(x=>x.Name).ToList();
        }
    }
}
