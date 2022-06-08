using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models.Authentication;
using DataCentre.Api.PreProcess;
using Jose;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    [Route("api/[controller]/data")]
    public class HomeController : BaseController
    {
        public HomeController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper) : base(Logger, RepositoryWrapper)
        {
            
        }
        [HttpGet]
        public string Get()
        {
            string token = Request.Headers["Authorization"];
            JwtAuthObject jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                        token,
                        Encoding.UTF8.GetBytes(Utility.Utility.key),
                        JwsAlgorithm.HS256);
            RepositoryContext context = _repositoryWrapper.GetRepositoryContext();
            var privList = from privilegeList in jwtObject.PrivilegeList
                         join privilege in context.Set<PrivilegeData>() on privilegeList.PrivilegeId equals privilege.Id
                         select new { privilege.Id, privilege.PrivilegeName, privilege.PrivilegeType };
                         //join privData in 
            
            return "";
        }
    }
}
