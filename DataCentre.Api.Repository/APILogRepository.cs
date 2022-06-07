using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;

namespace DataCentre.Api.Repository
{
    public class APILogRepository : RepositoryBase<APILog>, IRepositoryBase<APILog>
    {
        public APILogRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
