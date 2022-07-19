using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Admin;
using DataCentre.Api.Contracts.Product;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Repository.Admin;
using DataCentre.Api.Repository.Product;

namespace DataCentre.Api.Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DapperContext? _repositoryContext;
        public RepositoryWrapper(DapperContext context)
        {
            _repositoryContext = context;
        }
        // Declaration
        private ILoginDataRepository? _login;
        private IUserPrivilegeRepository? _userPrivilege;
        private IAPILogRepository? _apiLog;
        private IPrivilegeDataRepository? _privilegeData;
        private IProductReviewDataRepository? _productReviewData;
        private IProductTypeDataRepository? _productTypeDataRepository;
        private IProductClassDataRepository? _productClassDataRepository;
        private IProductDataRepository? _productData;
        private IMenuDataRepository? _menuData;
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
        public IMenuDataRepository MenuData 
        {
            get
            {
                if (_menuData == null)
                {
                    _menuData = new MenuDataRepository(_repositoryContext);
                }
                return _menuData;
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
