using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Product;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Product
{
    public class ProductClassDataRepository : RepositoryBase<ProductClass>, IProductClassDataRepository
    {
        public ProductClassDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
