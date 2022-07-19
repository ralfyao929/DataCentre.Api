using DataCentre.Api.Contracts.Admin;
using DataCentre.Api.Contracts.Product;
using DataCentre.Api.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Contracts
{
    public interface IRepositoryWrapper
    {
        ILoginDataRepository LoginData { get; }
        IUserPrivilegeRepository UserPrivilege { get; }
        IAPILogRepository APILog { get; }
        IPrivilegeDataRepository PrivilegeData { get; }
        IProductReviewDataRepository ProductReviewData { get; }
        IProductTypeDataRepository ProductTypeData { get; }
        IProductClassDataRepository ProductClassData { get; }
        IProductDataRepository ProductData { get; }
        IMenuDataRepository MenuData { get; }
        DapperContext GetRepositoryContext();
        //RepositoryContext GetRe
        //TO-DO Add Data Repository here...
        void Save();
    }
}
