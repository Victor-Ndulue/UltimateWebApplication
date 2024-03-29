﻿using Entities.Models;

namespace Contracts.EntityContracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompany(bool trackChanges);
        Company GetCompany(Guid companyId, bool trackChanges);
    }
}
