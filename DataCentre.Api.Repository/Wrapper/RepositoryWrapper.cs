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
        private RepositoryContext _repositoryContext;
        public RepositoryWrapper(RepositoryContext context)
        {
            _repositoryContext = context;
        }
        private ILoginDataRepository _login;
        private IUserPrivilegeRepository _userPrivilege;
        private IAPILogRepository _apiLog;

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
        //public ILoginDataRepository loginData => throw new NotImplementedException();
        public RepositoryContext GetRepositoryContext()
        {
            return _repositoryContext;
        }
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
