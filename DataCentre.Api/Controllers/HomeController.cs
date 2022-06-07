using DataCentre.Api.Contracts;
using DataCentre.Api.LoggerService;
using DataCentre.Api.PreProcess;
using Microsoft.AspNetCore.Mvc;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    [Route("api/[controller]/data")]
    public class HomeController : Controller
    {
        private static ILoggerManager _logger;
        private IRepositoryWrapper _repositoryWrapper;
        public HomeController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper)
        {
            _logger = Logger;
            _repositoryWrapper = RepositoryWrapper;
        }
        [HttpGet]
        public string Get()
        {
            return "value1";
        }
    }
}
