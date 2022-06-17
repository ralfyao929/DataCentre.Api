using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository
{
    public class SupplierReviewDataRepository : RepositoryBase<SupplierReview>, ISupplierReviewDataRepository
    {
        public SupplierReviewDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
