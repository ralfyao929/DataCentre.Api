using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository
{
    public class ProductReviewRepository : RepositoryBase<ProductReview>, IProductReviewDataRepository
    {
        public ProductReviewRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
