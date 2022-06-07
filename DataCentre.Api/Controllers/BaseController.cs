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
        public BaseController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper)
        {
            _logger = Logger;
            _repositoryWrapper = RepositoryWrapper;
        }
        //protected RepositoryContext GetRepositoryContext()
        //{
        //    return _repositoryWrapper.
        //}
    }
}
