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
                    jwtObject.PrivilegeList.ForEach(p =>
                    {
                        var dataPriv = privilegeData.FindByCondition(new { Id = p.PrivilegeId });
                        PrivilegeData p1 = null;
                        if (dataPriv.Count() > 0)
                        {
                            p1 = (PrivilegeData)dataPriv.ToArray()[0];
                        }
                        if (p1 != null && !string.IsNullOrEmpty(p1.PrivilegeUrl))
                        {
                            string[] privUrl = p1.PrivilegeUrl.Split(',');
                            foreach (string privUrlElm in privUrl)
                            {
                                if (actionContext.HttpContext.Request.Path == privUrlElm)
                                {
                                    hasPriv = true;
                                    break;
                                }
                            }
                        }
                        if (hasPriv)
                        {
                            return;
                        }
                    });
                    if (!hasPriv)
                    {
                        setErrorResponse(actionContext, "1003", "沒有權限取得相關資訊");
                        return;
                    }
                    
                }
                catch (Exception ex)
                {
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
                APILog log = new APILog();
                log.APIUrl = UriHelper.GetDisplayUrl(context.HttpContext.Request);
                log.Method = context.HttpContext.Request.Method;
                log.RequestJson = ((BaseController)context.Controller).RequestBody.ToString();//serJsonDetails.ToString();
                log.ResponseCode = context.HttpContext.Response.StatusCode.ToString();
                log.ResponseJson = (result != null && result.Value != null ? JsonConvert.SerializeObject(result.Value) : String.Empty);
                log.User = jwtObject.Id;
                log.CreatedTime = DateTime.Now;
                ((BaseController)context.Controller).GetRepositoryWrapper().APILog.Create(log);
            }
        }

        private static void setErrorResponse(ActionExecutingContext actionContext, string code, string message)
        {
            //UnauthorizedResult res = new UnauthorizedResult();
            //res.StatusCode = (int)HttpStatusCode.Unauthorized;
            if(code == "1003" || code == "1001")
                actionContext.Result = new UnauthorizedObjectResult(Utility.Utility.GetFailJsonStr(code, message));
            if (code == "9999")
                actionContext.Result = new BadRequestObjectResult(Utility.Utility.GetFailJsonStr(code, message));
        }
    }
}
