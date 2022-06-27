﻿using DataCentre.Api.Contracts.Accounting;
using DataCentre.Api.Contracts.Company;
using DataCentre.Api.Contracts.Product;
using DataCentre.Api.Contracts.Supplier;
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
        ICustomerReviewDataRepository CustomerReviewData { get; }
        IProductReviewDataRepository ProductReviewData { get; }
        ISupplierReviewDataRepository SupplierReviewData { get; }
        ISupplierDataRepository SupplierData { get; }
        ICloudAccountManageDataRepository CloudAccountManageReviewData { get; }
        IProductTypeDataRepository ProductTypeData { get; }
        IProductClassDataRepository ProductClassData { get; }
        ICompanyDataRepository CompanyData { get; }
        ICompanyUnitDataRepository CompanyUnitData { get; }
        IAccountingItemDataRepository AccountItemData { get; }
        IAccountingSubItemDataRepository AccountSubItemData { get; }
        IAccountingProdTypeDataRepository AccountProdTypeData { get; }
        IProductDataRepository ProductData { get; }
        DapperContext GetRepositoryContext();
        //RepositoryContext GetRe
        //TO-DO Add Data Repository here...
        void Save();
    }
}
