using DataCentre.Api.Contracts;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataCentre.Api.Controllers
{
    [Route("api/[controller]/data")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper, IConfiguration iConfig) : base(Logger, RepositoryWrapper, iConfig)
        {
        }
        [HttpGet]
        public ApiResult<object> Get()
        {
            ApiResult<object> result = new ApiResult<object>(_localizer.GetValue<string>("AppSettings:localize"));
            try
            {

            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
