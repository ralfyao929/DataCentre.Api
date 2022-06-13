using DataCentre.Api.Models.Authentication;
using Jose;
using System.Net;
using System.Text;
using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Features;

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
            if (string.IsNullOrEmpty(actionContext.HttpContext.Request.Headers.Authorization))
            {
                setErrorResponse(actionContext, "9999", "驗證錯誤");
            }
            else
            {
                try
                {
                    var jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                        actionContext.HttpContext.Request.Headers.Authorization,
                        Encoding.UTF8.GetBytes(Utility.Utility.key),
                        JwsAlgorithm.HS256);
                    if(jwtObject.exp.CompareTo(DateTime.Now) < 0)
                    {
                        setErrorResponse(actionContext, "1001", "憑證過期");
                        //return;
                    }
                }
                catch (Exception ex)
                {
                    setErrorResponse(actionContext, "9999", "未知的錯誤");
                    //return;
                }
            }
            base.OnActionExecuting(actionContext);
        }

        private static void setErrorResponse(ActionExecutingContext actionContext, string code, string message)
        {
            actionContext.HttpContext.Response.WriteAsync(Utility.Utility.GetFailJsonStr(code, message));
            //actionContext.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = message;
            //actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }

        //public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        //{
        //    //throw new NotImplementedException();
        //}
    }
}
