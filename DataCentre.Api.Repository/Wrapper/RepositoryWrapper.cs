using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Accounting;
using DataCentre.Api.Contracts.Company;
using DataCentre.Api.Contracts.Product;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Repository.Accounting;
using DataCentre.Api.Repository.Company;
using DataCentre.Api.Repository.Customer;
using DataCentre.Api.Repository.Product;
using DataCentre.Api.Repository.Cloud;
using DataCentre.Api.Repository.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCentre.Api.Contracts.Supplier;

namespace DataCentre.Api.Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DapperContext _repositoryContext;
        public RepositoryWrapper(DapperContext context)
        {
            _repositoryContext = context;
        }
        // Declaration
        private ILoginDataRepository? _login;
        private IUserPrivilegeRepository? _userPrivilege;
        private IAPILogRepository? _apiLog;
        private IPrivilegeDataRepository? _privilegeData;
        private ICustomerReviewDataRepository? _customerReviewData;
        private IProductReviewDataRepository? _productReviewData;
        private ISupplierReviewDataRepository? _supplierReviewData;
        private ISupplierDataRepository? _supplierData;
        private ICloudAccountManageDataRepository? _cloudAccountManageData;
        private IProductTypeDataRepository? _productTypeDataRepository;
        private IProductClassDataRepository? _productClassDataRepository;
        private ICompanyDataRepository? _companyDataRepository;
        private ICompanyUnitDataRepository? _companyUnitDataRepository;
        private IAccountingItemDataRepository? _accountingItemDataRepository;
        private IAccountingSubItemDataRepository? _accountingSubItemDataRepository;
        private IAccountingProdTypeDataRepository? _accountProdTypeData;
        private IProductDataRepository? _productData;
        // Implementation
        public ILoginDataRepository LoginData
        {
            get
            {
                if (_login == null)
                {
                    _login = new LoginDataRepository(_repositoryContext);
                }
                return _login;
            }
        }
        public IUserPrivilegeRepository UserPrivilege
        {
            get
            {
                if (_userPrivilege == null)
                {
                    _userPrivilege = new UserPrivilegeRepository(_repositoryContext);
                }
                return _userPrivilege;
            }
        }
        public IAPILogRepository APILog
        {
            get
            {
                if (_apiLog == null)
                {
                    _apiLog = new APILogRepository(_repositoryContext);
                }
                return _apiLog;
            }
        }
        public IPrivilegeDataRepository PrivilegeData
        {
            get
            {
                if (_privilegeData == null)
                {
                    _privilegeData = new PrivilegeDataRepository(_repositoryContext);
                }
                return _privilegeData;
            }
        }
        public ICustomerReviewDataRepository CustomerReviewData
        {   
            get 
            {
                if (_customerReviewData == null)
                {
                    _customerReviewData = new CustomerReviewRepository(_repositoryContext);
                }
                return _customerReviewData;
            } 
        }
        public IProductReviewDataRepository ProductReviewData
        {
            get
            {
                if (_productReviewData == null)
                {
                    _productReviewData = new ProductReviewRepository(_repositoryContext);
                }
                return _productReviewData;
            }
        }
        public ISupplierReviewDataRepository SupplierReviewData 
        { 
            get 
            {
                if (_supplierReviewData == null)
                {
                    _supplierReviewData = new SupplierReviewDataRepository(_repositoryContext);
                }
                return _supplierReviewData;
            } 
        }
        public ISupplierDataRepository SupplierData
        {
            get
            {
                if (_supplierData == null)
                {
                    _supplierData = new SupplierDataRepository(_repositoryContext);
                }
                return _supplierData;
            }
        }
        public ICloudAccountManageDataRepository CloudAccountManageReviewData
        {
            get
            {
                if (_cloudAccountManageData == null)
                {
                    _cloudAccountManageData = new CloudAccountManageReviewDataRepository(_repositoryContext);
                }
                return _cloudAccountManageData;
            }
        }
        public IProductTypeDataRepository ProductTypeData
        {
            get
            {
                if (_productTypeDataRepository == null)
                {
                    _productTypeDataRepository = new ProductTypeDataRepository(_repositoryContext);
                }
                return _productTypeDataRepository;
            }
        }
        public IProductClassDataRepository ProductClassData
        {
            get
            {
                if (_productClassDataRepository == null)
                {
                    _productClassDataRepository = new ProductClassDataRepository(_repositoryContext);
                }
                return _productClassDataRepository;
            }
        }
        public ICompanyDataRepository CompanyData 
        { 
            get 
            {
                if (_companyDataRepository == null)
                {
                    _companyDataRepository = new CompanyDataRepository(_repositoryContext);
                }
                return _companyDataRepository;
            } 
        }
        public ICompanyUnitDataRepository CompanyUnitData
        {
            get
            {
                if (_companyUnitDataRepository == null)
                {
                    _companyUnitDataRepository = new CompanyUnitDataRepository(_repositoryContext);
                }
                return _companyUnitDataRepository;
            }
        }
        public IAccountingItemDataRepository AccountItemData 
        {
            get
            {
                if (_accountingItemDataRepository == null)
                {
                    _accountingItemDataRepository = new AccountingItemDataRepository(_repositoryContext);
                }
                return _accountingItemDataRepository;
            }
        }
        public IAccountingSubItemDataRepository AccountSubItemData 
        {
            get
            {
                if (_accountingSubItemDataRepository == null)
                {
                    _accountingSubItemDataRepository = new AccountingSubItemDataRepository(_repositoryContext);
                }
                return _accountingSubItemDataRepository;
            }
        }
        public IAccountingProdTypeDataRepository AccountProdTypeData 
        {
            get
            {
                if (_accountProdTypeData == null)
                {
                    _accountProdTypeData = new AccountingProductTypeDataRepository(_repositoryContext);
                }
                return _accountProdTypeData;
            }
        }
        public IProductDataRepository ProductData {
            get
            {
                if (_productData == null)
                {
                    _productData = new ProductDataRepository(_repositoryContext);
                }
                return _productData;
            }
        }
        public DapperContext GetRepositoryContext()
        {
            return _repositoryContext;
        }
        public void Save()
        {
            //_repositoryContext
        }
    }
}
