using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.PreProcess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/data")]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    public class PermissionController : BaseController
    {
        public PermissionController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper) : base(Logger, RepositoryWrapper)
        {

        }
        [HttpGet]
        public string Get(int id)
        {
            try
            {
                RepositoryContext context = _repositoryWrapper.GetRepositoryContext();
                var privList = context.Set<PrivilegeData>().GroupJoin(
                                context.Set<UserPrivilege>(),
                                    a => a.Id,
                                    b => b.PrivilegeId,
                                    (a, b) => new { a.Id, a.PrivilegeName, a.PrivilegeType, b }
                                ).SelectMany(
                                    x => x.b.DefaultIfEmpty(),
                                    (s, t) => new {s.Id, s.PrivilegeName, s.PrivilegeType, t.PrivilegeGroup}
                                ).GroupJoin(context.Set<LoginData>().Where(s => s.id == id),
                                    a => a.PrivilegeGroup,
                                    b => b.PrivilegeGroup,
                                    (a, b) =>new {a.Id, a.PrivilegeName, a.PrivilegeType, b})
                                .SelectMany(
                                    x=> x.b.DefaultIfEmpty(),
                                    (y, z) => new {id = y.Id, name = y.PrivilegeName, type = y.PrivilegeType, isHave = string.IsNullOrEmpty(z.PrivilegeGroup) ? false : true}
                                );
                return Utility.Utility.GetSuccessJsonStr("\"data\":"+JsonConvert.SerializeObject(privList.ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                return Utility.Utility.GetFailJsonStr("9999", "系統發生錯誤，請洽系統管理人員");
            }
        }
    }
}
