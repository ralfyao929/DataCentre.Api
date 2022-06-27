using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models.Accounting;
using DataCentre.Api.Entity.Models.Generic;
using DataCentre.Api.Entity.Models.Product;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models;
using DataCentre.Api.Models.Authentication;
using DataCentre.Api.Module.Product;
using DataCentre.Api.Module;
using DataCentre.Api.View;
using Jose;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DataCentre.Api.Controllers
{ 
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : BaseController
    {
        public ProductController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper, IConfiguration iConfig) : base(Logger, RepositoryWrapper, iConfig)
        {
        }
        /// <summary>
        /// 產品維護--取得表單內容
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResult<ProductMainView> data()
        {
            ApiResult<ProductMainView> result = new ApiResult<ProductMainView>(_localizer.GetValue<string>("AppSettings:localize"));
            try
            {
                ProductModule module = new ProductModule(_repositoryWrapper);
                ProductMainView MainView = module.GetProductMainView();
                result.Code = "0000";
                result.Result = MainView;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
        [HttpGet]
        public ApiResult<ProductMainView> home(string? productName)
        {
            ApiResult<ProductMainView> result = new ApiResult<ProductMainView>(_localizer.GetValue<string>("AppSettings:localize"));
            try
            {
                ProductMainView MainView = new ProductMainView();
                ProductModule productModule = new ProductModule(_repositoryWrapper);
                if (string.IsNullOrEmpty(productName))
                {
                    MainView.productName = productModule.GetProductNameList();
                }
                else
                {
                    MainView.productName2 = productModule.GetProductName2List(productName);
                }
                result.Code = "0000";
                result.Result = MainView;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
        [HttpGet]
        public ApiResult<ProductView> data(string? productName2)
        {
            ApiResult<ProductView> result = new ApiResult<ProductView>();
            ProductModule productModule = new ProductModule(_repositoryWrapper);
            ProductView productView = new ProductView();
            Product product = null;
            try
            {
                product = productModule.GetProductView(productName2);
                productView.product = product;
                productView.prodMainView = productModule.GetProductMainView();
                result.Result = productView;
                result.Code = "0000";
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
        [HttpGet]
        public ApiResult<List<Product>> dataList(int? productTypeId, string? productName1, string? productName2, int? personInChargeName, string? supplierName)
        {
            ApiResult<List<Product>> result = new ApiResult<List<Product>>();
            ProductModule productModule = new ProductModule(_repositoryWrapper);
            try
            {
                List<Product> products = productModule.GetProductConditionList(productTypeId, productName1, productName2, personInChargeName, supplierName);
                result.Result = products;
                result.Code = "0000";
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
        [HttpPost]
        public ApiResult<object> data(ProductReview data)
        {
            ApiResult<object> result = new ApiResult<object>();
            ProductModule productModule = new ProductModule(_repositoryWrapper);
            try
            {

                // 取得使用者權限列表
                string token = Request.Headers["Authorization"];
                JwtAuthObject jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                            token,
                            Encoding.UTF8.GetBytes(Utility.Utility.key),
                            JwsAlgorithm.HS256);
                // 1.	產品細項不可重複
                bool isProdName2Dup = productModule.GetProductname2Dup(data.productName2);
                if(isProdName2Dup)
                {
                    result.Code = "2005";
                    return result;
                }
                // 2.	供應商id是否存在
                //bool isSupplierExist = 
                bool hasProductAudit = false;
                jwtObject.PrivilegeList.ForEach(o => 
                { 
                    if (o.PrivilegeId == 9)
                    {
                        hasProductAudit = true;
                        return;
                    }
                });
                if(hasProductAudit)
                {
                    // 權限只要擁有產品維護(檢核)->直接寫到[產品資料]
                }
                else
                {
                    // 權限只有產品維護->寫到[請求新增、修改刪除產品資料]、[請求產品資料隸屬公司]，因為要審核
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
    }
}
