using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Product;
using DataCentre.Api.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Product
{
    public class ProductTypeDataRepository : RepositoryBase<ProductType>, IProductTypeDataRepository
    {
        public ProductTypeDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
