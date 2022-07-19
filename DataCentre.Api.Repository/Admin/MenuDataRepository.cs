using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Admin;
using DataCentre.Api.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Admin
{
    internal class MenuDataRepository : RepositoryBase<Menu>, IMenuDataRepository
    {
        public MenuDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
