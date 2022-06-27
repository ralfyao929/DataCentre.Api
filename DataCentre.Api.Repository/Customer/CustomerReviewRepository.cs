using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Customer
{
    public class CustomerReviewRepository : RepositoryBase<CustomerReview>, ICustomerReviewDataRepository
    {
        public CustomerReviewRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
