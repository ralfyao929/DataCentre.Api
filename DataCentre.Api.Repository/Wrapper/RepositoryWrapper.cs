using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
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
                if (_privilegeData == null)
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
