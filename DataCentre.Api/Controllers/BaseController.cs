using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Localize;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


namespace DataCentre.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected static ILoggerManager _logger;
        protected IRepositoryWrapper _repositoryWrapper;
        protected readonly IConfiguration _localizer;
        public object RequestBody = string.Empty;
        public object ResponseBody = string.Empty;
        public BaseController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper, IConfiguration iConfig)
        {
            _logger = Logger;
            _repositoryWrapper = RepositoryWrapper;
            _localizer = iConfig;
        }
        public IRepositoryWrapper GetRepositoryWrapper()
        {
            return _repositoryWrapper;
        }
        //protected RepositoryContext GetRepositoryContext()
        //{
        //    return _repositoryWrapper.
        //}
    }
}
