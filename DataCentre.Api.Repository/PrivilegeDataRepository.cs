using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository
{
    public class PrivilegeDataRepository : RepositoryBase<PrivilegeData>, IPrivilegeDataRepository
    {
        public PrivilegeDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
