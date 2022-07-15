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
    public class ProductDataRepository : RepositoryBase<DataCentre.Api.Entity.Models.Product>, IProductDataRepository
    {
        public ProductDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
