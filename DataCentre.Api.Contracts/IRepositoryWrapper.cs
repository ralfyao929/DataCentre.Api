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
        DapperContext GetRepositoryContext();
        //RepositoryContext GetRe
        //TO-DO Add Data Repository here...
        void Save();
    }
}
