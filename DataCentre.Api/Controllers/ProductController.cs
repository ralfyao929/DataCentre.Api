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
using DataCentre.Api.Module.Supplier;
using System.Reflection;
using DataCentre.Api.Entity.Models.Sales;

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
            SupplierModule supplierModule = new SupplierModule(_repositoryWrapper);
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
                var suppliers = _repositoryWrapper.SupplierData.FindByCondition(s => s.SupplierId == data.supplierName);
                // 2.   新增產品的時候，有相對應的公司沒有供應商名字
                if (suppliers.Count() == 0)
                {
                    result.Code = "3013";
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
                    // 檢查產品資料是否存在，如存在則Update
                    Product product = new Product();
                    product.ProductId = productModule.GetLatestProductId();
                    product.productName1 = data.productName1;
                    product.productName2 = data.productName2;
                    product.productTypeId = data.productTypeId;
                    product.productClassId = data.productClassId;
                    product.supplierName = data.supplierName;
                    product.personInChargeId = data.personInChargeId;
                    product.departmentId = int.Parse(data.departmentId);
                    product.accounting = data.accounting;
                    product.accountingBranch = data.accountingBranch;
                    product.accountingProductType = data.accountingProductType;
                    product.isSetCost = data.isSetCost;
                    product.createUser = data.createUser;
                    product.createdTime = data.createdTime;
                    string[] strCompanyArr = data.companyIdArr.Split(',');
                    foreach (string comp in strCompanyArr)
                    {
                        product.companyId = int.Parse(comp);
                        _repositoryWrapper.ProductData.Create(product);
                    }
                }
                else
                {
                    // 權限只有產品維護->寫到[請求新增、修改刪除產品資料]、[請求產品資料隸屬公司]，因為要審核
                    _repositoryWrapper.ProductReviewData.Create(data);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
        public ApiResult<object> review(int productId, int reviewStatus, string reason)
        {
            ApiResult<object> result = new ApiResult<object>();
            try
            {
                string token = Request.Headers["Authorization"];
                JwtAuthObject jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                            token,
                            Encoding.UTF8.GetBytes(Utility.Utility.key),
                            JwsAlgorithm.HS256);
                bool hasProductAudit = false;
                ProductModule pm = new ProductModule(_repositoryWrapper);
                jwtObject.PrivilegeList.ForEach(o =>
                {
                    if (o.PrivilegeId == 9)
                    {
                        hasProductAudit = true;
                        return;
                    }
                });
                if(!hasProductAudit)
                {
                    result.Code = "1009";//您沒有權限審核產品資料
                    return result;
                }
                var ProductList = _repositoryWrapper.ProductReviewData.FindByCondition(pr => pr.id == productId);
                if(ProductList.Count() > 0)
                {
                    var ProductReviewData = ProductList.ToList()[0];//要審核的產品資料
                    if(ProductReviewData.reviewStatus == 1)
                    {
                        result.Code = "4003";//審核失敗，因為審核狀態已完成。
                        return result;
                    }
                    var ProductToReview_Name2 = _repositoryWrapper.ProductData.FindByCondition(p => p.productName2 == ProductReviewData.productName2);
                    if(ProductToReview_Name2.Count() > 0)
                    {
                        result.Code = "2005";//產品細項欄位重複了
                        return result;
                    }
                    var supplierList = _repositoryWrapper.SupplierData.FindByCondition(s => s.id == ProductReviewData.supplierName);
                    if(supplierList.Count() == 0)
                    {
                        result.Code = "3013";//新增產品的時候，有相對應的公司沒有供應商名字
                        return result;
                    }
                    if(ProductReviewData.companyIdArr != null && string.IsNullOrEmpty(ProductReviewData.companyIdArr.Trim()))
                    {
                        result.Code = "3014";//負責公司至少要有1個
                        return result;
                    }
                    //產品減少負責公司時候：需判斷該負責公司的產品是否->
                    // 1.已經有開過訂單、雲端帳號使用了，都不可以減少
                    //var ProductToReview = _repositoryWrapper.ProductData.FindByCondition(p => p.ProductId == ProductReviewData.ProductId);
                    //int orderCloudUsedCount = 0;
                    //if(ProductToReview.Count() > 0)
                    //{
                    //    string[] companyOwnReview = ProductReviewData.companyIdArr.Split(',');
                    //    foreach (Product pp in ProductToReview)
                    //    {
                    //        var orderUsedList = pm.GetOrderUsedList(pp.ProductId, pp.companyId);
                    //        orderCloudUsedCount += orderUsedList.Count();
                    //        var cloudUsedList = pm.GetCloudUsedList(pp.ProductId, pp.companyId);
                    //        orderCloudUsedCount += cloudUsedList.Count();
                    //        int inDex = 0;
                    //        foreach(string companyReview in companyOwnReview)
                    //        {
                    //            if(companyReview == pp.companyId.ToString())
                    //            {

                    //            }
                    //        }
                    //    }
                    //    bool isOrderCloudUsedProd = false;
                    //    if (orderCloudUsedCount > 0)
                    //        isOrderCloudUsedProd = true;
                        
                        
                    //}
                    //var Product_List = _repositoryWrapper.ProductData.FindByCondition(p)
                    //string[] companyList = ProductReviewData.companyIdArr.Split(',');
                    //foreach(string company in companyList)
                    //{
                    //    var company1_List = _repositoryWrapper.CompanyData.FindByCondition(c => c.id == int.Parse(company));
                    //    if(company1_List.Count() > 0)
                    //    {
                    //        Company c1 = (Company)company1_List.ToList()[0];
                    //        if(c1.Supp)
                    //    }
                    //}
                }
                else
                {
                    result.Code = "4011";//審核失敗，該待審核產品資料不存在。
                    return result;
                }
                //var ProductReviewList = _repositoryWrapper.ProductReviewData.FindByCondition(pr => pr.id == productId);
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
