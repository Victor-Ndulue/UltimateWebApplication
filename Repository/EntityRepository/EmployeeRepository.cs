using Contracts.EntityContracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityRepository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            return FindAllAsync(trackChanges)
                .OrderByDescending(x => x.Name)
                .ToList();

        }
    }
}
