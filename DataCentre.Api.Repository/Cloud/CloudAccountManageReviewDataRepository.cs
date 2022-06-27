using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity.Models.Cloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Cloud
{
    public class CloudAccountManageReviewDataRepository : RepositoryBase<CloudAccountManageReview>, ICloudAccountManageDataRepository
    {
        public CloudAccountManageReviewDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
