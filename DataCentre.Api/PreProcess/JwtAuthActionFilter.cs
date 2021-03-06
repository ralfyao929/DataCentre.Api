using DataCentre.Api.Models.Authentication;
using Jose;
using System.Net;
using System.Text;
using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using DataCentre.Api.Entity.Models;
using Microsoft.AspNetCore.Http.Extensions;
using DataCentre.Api.Controllers;
using DataCentre.Api.Contracts;
using Newtonsoft.Json;
using System.IO.Pipelines;
using System.Text.Json;

namespace DataCentre.Api.PreProcess
{
    //在需要token授權的api前面加上[JwtAuthActionFilter]
    //ex:
    /*
     * 
    [JwtAuthActionFilter]
    public class ValuesController : ApiController
    {   
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
     *
     */
    //[Filter]
    public class JwtAuthActionFilter : ActionFilterAttribute
    {
        public string RequestBody = string.Empty;
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.Path == "/api/login" 
             || actionContext.HttpContext.Request.Path == "/api/home/data")
            {
                return;
            }
            if (string.IsNullOrEmpty(actionContext.HttpContext.Request.Headers.Authorization))
            {
                setErrorResponse(actionContext, "9999", "驗證錯誤");
                return;
            }
            else
            {
                try
                {
                    var jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                        actionContext.HttpContext.Request.Headers.Authorization,
                        Encoding.UTF8.GetBytes(Utility.Utility.key),
                        JwsAlgorithm.HS256);
                    if (jwtObject.exp.CompareTo(DateTime.Now) < 0)
                    {
                        setErrorResponse(actionContext, "1001", "憑證過期");
                        return;
                    }
                    IPrivilegeDataRepository privilegeData = ((BaseController)actionContext.Controller).GetRepositoryWrapper().PrivilegeData;
                    bool hasPriv = false;
                    var privilegeList = privilegeData.FindByCondition(new { UserID = jwtObject.Id });
                    privilegeList.ToList().ForEach(p => 
                    {
                        var menuList = ((BaseController)actionContext.Controller).GetRepositoryWrapper().MenuData.FindByCondition(new { MenuParentCode=p.FuncListID });
                        menuList.ToList().ForEach(m => 
                        { 
                            if(m.MenuCodeName == actionContext.HttpContext.Request.Path.ToString())
                            {
                                hasPriv = true;
                            }
                        });
                    });
                    if (!hasPriv)
                    {
                        setErrorResponse(actionContext, "1003", "沒有權限取得相關資訊");
                        return;
                    }
                    RequestBody = JsonConvert.SerializeObject(actionContext.ActionArguments);
                }
                catch (Exception ex)
                {
                    using(StreamWriter writer = File.AppendText(@"./err"+DateTime.Now.ToString("yyyyMmddHHmmssfff")+".log"))
                    {
                        writer.WriteLine(ex + ex.StackTrace);
                    }
                    setErrorResponse(actionContext, "9999", "未知的錯誤");
                    return;
                    //return;
                }
            }
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Path == "/api/login")
            {
                return;
            }
            ObjectResult? result = (ObjectResult?)context.Result;
            if(result != null)
            {
                var jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                        context.HttpContext.Request.Headers.Authorization,
                        Encoding.UTF8.GetBytes(Utility.Utility.key),
                        JwsAlgorithm.HS256);
                LogAPI log = new LogAPI();
                log.LogAPIUrl = UriHelper.GetDisplayUrl(context.HttpContext.Request);
                log.LogAPIMethod = context.HttpContext.Request.Method;
                log.LogAPIInputData = RequestBody;//serJsonDetails.ToString();
                log.LogAPIResponeCode = context.HttpContext.Response.StatusCode.ToString();
                log.LogAPIOuptData = (result != null && result.Value != null ? JsonConvert.SerializeObject(result.Value) : String.Empty);
                log.LogAPICallUser = jwtObject.Id.ToString();
                log.createdTime = DateTime.Now;
                ((BaseController)context.Controller).GetRepositoryWrapper().APILog.Create(log);
            }
        }

        private static void setErrorResponse(ActionExecutingContext actionContext, string code, string message)
        {
            if(code == "1003" || code == "1001")
                actionContext.Result = new UnauthorizedObjectResult(Utility.Utility.GetFailJsonStr(code, message));
            if (code == "9999")
                actionContext.Result = new BadRequestObjectResult(Utility.Utility.GetFailJsonStr(code, message));
        }
    }
}
