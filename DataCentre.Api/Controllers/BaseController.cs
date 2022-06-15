using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace DataCentre.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected static ILoggerManager _logger;
        protected IRepositoryWrapper _repositoryWrapper;
        public object RequestBody = string.Empty;
        public object ResponseBody = string.Empty;
        public BaseController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper)
        {
            _logger = Logger;
            _repositoryWrapper = RepositoryWrapper;
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
