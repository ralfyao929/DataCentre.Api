using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Localize;
using DataCentre.Api.Models.Authentication;
using DataCentre.Api.PreProcess;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Text;
using DataCentre.Api.Models;
using DataCentre.Api.View;
using Microsoft.Extensions.Localization;
using DataCentre.Api.Module;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    [Route("api/[controller]/data")]
    public class HomeController : BaseController
    {
        
        public HomeController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper, IConfiguration iConfig) : base(Logger, RepositoryWrapper, iConfig)
        {
            
        }
        [HttpGet]
        public ApiResult<HomeView> Get()
        {
            //APILog log = new APILog();
            ApiResult<HomeView> apiResult = new ApiResult<HomeView>(_localizer.GetValue<string>("AppSettings:localize"));
            try
            {
                string token = Request.Headers["Authorization"];
                JwtAuthObject jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                            token,
                            Encoding.UTF8.GetBytes(Utility.Utility.key),
                            JwsAlgorithm.HS256);
                var privList = from privilegeList in jwtObject.PrivilegeList
                               join privilege in _repositoryWrapper.PrivilegeData.findAll() on privilegeList.PrivilegeId equals privilege.Id
                               select new { privilege.Id, privilege.PrivilegeName, privilege.PrivilegeType };
                var prodReviewList = _repositoryWrapper.ProductReviewData.FindByCondition(new { reviewStatus = 0 });
                //var custReviewList = _repositoryWrapper.CustomerReviewData.FindByCondition(new { ReviewStatus = 0 });
                //var suppReviewList = _repositoryWrapper.SupplierReviewData.FindByCondition(new { ReviewStatus = 0 });
                //var cloudReviewList = _repositoryWrapper.CloudAccountManageReviewData.FindByCondition(new { ReviewStatus = 0 });
                // 雲端帳號維護(審核)->雲端帳號管理待審核<-取有幾筆要審核
                //Notification cloudNotify = new Notification();
                //cloudNotify.id = 3;
                //cloudNotify.count = cloudReviewList.Count();
                //// 產品維護(檢核)->請求新增、修改刪除產品資料<-取有幾筆要審核
                //Notification prodNotify = new Notification();
                //prodNotify.id = 2;
                //prodNotify.count = prodReviewList.Count();
                //// 客戶維護(檢核)->請求異動客戶資料<-取有幾筆要審核
                //Notification custNotify = new Notification();
                //custNotify.id = 1;
                //custNotify.count = custReviewList.Count();
                //// 供應商維護(檢核)->請求異動供應商資料<-取有幾筆要審核
                //Notification suppNotify = new Notification();
                //suppNotify.id = 0;
                //suppNotify.count = suppReviewList.Count();

                HomeView HomeViews = new HomeView();
                HomeViews.data = privList;
                HomeViews.notify = new List<Notification>();
                //HomeViews.notify.Add(cloudNotify);
                //HomeViews.notify.Add(prodNotify);
                //HomeViews.notify.Add(custNotify);
                //HomeViews.notify.Add(suppNotify);

                apiResult.Code = "0000";
                apiResult.Result = HomeViews;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                apiResult.Code = "9999";
                apiResult.Message = "未知的錯誤，請洽系統管理人員";
            }
            return apiResult;
        }
    }
}
