using DataCentre.Api.Models.Authentication;
using Jose;
using System.Net;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

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
    public class JwtAuthActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                setErrorResponse(actionContext, "驗證錯誤");
            }
            else
            {
                try
                {
                    var jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                        actionContext.Request.Headers.Authorization.Parameter,
                        Encoding.UTF8.GetBytes(Utility.Utility.key),
                        JwsAlgorithm.HS256);
                    if(jwtObject.exp.CompareTo(DateTime.Now) < 0)
                    {
                        setErrorResponse(actionContext, "憑證過期");
                    }
                }
                catch (Exception ex)
                {
                    setErrorResponse(actionContext, ex.Message);
                }
            }

            base.OnActionExecuting(actionContext);
        }

        private static void setErrorResponse(HttpActionContext actionContext, string message)
        {
            var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
            actionContext.Response = response;
        }
    }
}
