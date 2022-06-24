using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Company;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Company
{
    public class CompanyUnitDataRepository : RepositoryBase<CompanyUnit>, ICompanyUnitDataRepository
    {
        public CompanyUnitDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
