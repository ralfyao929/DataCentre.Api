using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Product;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Repository.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DapperContext _repositoryContext;
        public RepositoryWrapper(DapperContext context)
        {
            _repositoryContext = context;
        }
        private ILoginDataRepository _login;
        private IUserPrivilegeRepository _userPrivilege;
        private IAPILogRepository _apiLog;
        private IPrivilegeDataRepository _privilegeData;
        private ICustomerReviewDataRepository _customerReviewData;
        private IProductReviewDataRepository _productReviewData;
        private ISupplierReviewDataRepository _supplierReviewData;
        private ICloudAccountManageDataRepository _cloudAccountManageData;
        private IProductTypeDataRepository _productTypeDataRepository;
        private IProductClassDataRepository _productClassDataRepository;

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
