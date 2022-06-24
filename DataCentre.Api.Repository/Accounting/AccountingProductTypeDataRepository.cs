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
    public class AccountingProductTypeDataRepository : RepositoryBase<AccountingProductType>, IAccountingProdTypeDataRepository
    {
        public AccountingProductTypeDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
