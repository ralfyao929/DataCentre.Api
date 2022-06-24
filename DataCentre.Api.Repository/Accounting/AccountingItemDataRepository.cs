using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Accounting;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Accounting
{
    public class AccountingItemDataRepository : RepositoryBase<AccountingItem>, IAccountingItemDataRepository
    {
        public AccountingItemDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
