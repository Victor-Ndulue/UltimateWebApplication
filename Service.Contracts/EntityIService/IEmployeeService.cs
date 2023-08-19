using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.EntityIService
{
    public interface IEmployeeService
    {
       IEnumerable<Employee> GetAllEmployees(bool trackChanges); 
    }
}
