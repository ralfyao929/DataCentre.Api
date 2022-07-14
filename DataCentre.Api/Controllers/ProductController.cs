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
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity;

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
        /// <summary>
        /// 產品維護-主頁
        /// </summary>
        /// <param name="productName">產品名稱</param>
        /// <returns>頁面上需要帶出的下拉清單資料</returns>
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
        /// <summary>
        /// 產品維護-查詢
        /// </summary>
        /// <param name="productName2">產品細項</param>
        /// <returns>產品詳細資料內容</returns>
        [HttpGet]
        public ApiResult<ProductView> dataList(string? productName2)
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
        /// <summary>
        /// 產品維護-刪除
        /// </summary>
        /// <param name="productName2">要刪除的產品細項</param>
        /// <returns>刪除結果</returns>
        public ApiResult<object> delete(string productName2) 
        {
            ApiResult<object> result = new ApiResult<object>();
            try
            {
                string token = Request.Headers["Authorization"];
                JwtAuthObject jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                            token,
                            Encoding.UTF8.GetBytes(Utility.Utility.key),
                            JwsAlgorithm.HS256);
                bool hasProductMaintain = false;
                #region 1004 您沒有權限申請新增/刪除/修改相關資訊
                jwtObject.PrivilegeList.ForEach(o =>
                {
                    if (o.PrivilegeId == 8 || o.PrivilegeId == 9)
                    {
                        hasProductMaintain = true;
                        return;
                    }
                });
                if(!hasProductMaintain)
                {
                    result.Code = "1004";//您沒有權限審核產品資料
                    return result;
                }
                #endregion

            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
        /// <summary>
        /// 產品維護-查詢列表
        /// 查詢要審核的產品清單
        /// </summary>
        /// <param name="productTypeId">產品型別</param>
        /// <param name="productName1">產品細項總稱</param>
        /// <param name="productName2">產品細項</param>
        /// <param name="personInChargeName">負責人ID</param>
        /// <param name="supplierName">供應商ID</param>
        /// <returns></returns>
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
        /// <summary>
        /// 產品新增/修改，寫資料到[請求產品審核]資料表
        /// 以oldProductId來判斷是否為新增或修改
        /// </summary>
        /// <param name="data">要新增/修改的產品</param>
        /// <returns>執行結果</returns>
        [HttpPost]
        public ApiResult<object> data(ProductView data)
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
                data.reviewStatus = (int)ReviewType.Request;
                if (data.oldProductId == null)//新增
                {
                    if (hasProductAudit)
                    {
                        // 權限只要擁有產品維護(檢核)->直接寫到[產品資料]
                        // 檢查產品資料是否存在，如存在則Update
                        Product product = new Product();
                        product.ProductId = productModule.GetLatestProductId();
                        product.productName1 = data.productName1;
                        product.productName2 = data.productName2;
                        product.productTypeId = (int)(data.productTypeId != null ? data.productTypeId : -1);
                        product.productClassId = (int)(data.productClassId != null ? data.productClassId : -1);
                        product.supplierName = (int)(data.supplierName != null ? data.supplierName : -1);
                        product.personInChargeId = (int)(data.personInChargeId != null ? data.personInChargeId : -1);
                        product.departmentId = (int)(data.departmentId != null ? data.departmentId : -1);
                        product.accounting = (int)(data.accounting != null ? data.accounting : -1);
                        product.accountingBranch = (int)(data.accountingBranch != null ? data.accountingBranch : -1);
                        product.accountingProductType = (int)(data.accountingProductType != null ? data.accountingProductType : -1);
                        product.isSetCost = (int)(data.isSetCost != null ? data.isSetCost : -1);
                        product.createUser = jwtObject.Id;//data. != null ? data.createUser : "";
                        product.createdTime = DateTime.Now;
                        string[] strCompanyArr = (data.companyIdArray != null ? data.companyIdArray.Split(',') : null);
                        if (strCompanyArr != null)
                        {
                            foreach (string comp in strCompanyArr)
                            {
                                product.companyId = int.Parse(comp);
                                _repositoryWrapper.ProductData.Create(product);
                            }
                        }
                        else
                        {
                            result.Code = "3014";//負責公司至少要有1個
                            return result;
                        }
                    }
                    else
                    {
                        // 權限只有產品維護->寫到[請求新增、修改刪除產品資料]、[請求產品資料隸屬公司]，因為要審核
                        data.reviewStatus = (int)RequestType.Add;
                        _repositoryWrapper.ProductReviewData.Create((ProductReview)data);
                    }
                }
                else
                {
                    data.requestType = (int)RequestType.Modify;
                    _repositoryWrapper.ProductReviewData.Update((ProductReview)data);
                }
                result.Code = "0000";//成功
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
        /// <summary>
        /// 產品審核，將資料由[請求產品審核]資料表寫到[產品]資料表
        /// </summary>
        /// <param name="productId">要審核的請求審核產品資料ID</param>
        /// <param name="reviewStatus">審核結果</param>
        /// <param name="reason">退回原因</param>
        /// <returns></returns>
        [HttpGet]
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
                #region 1009 您沒有權限審核產品資料
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
                #endregion
                var ProductList = _repositoryWrapper.ProductReviewData.FindByCondition(pr => pr.id == productId);
                if(ProductList.Count() > 0)
                {
                    var ProductReviewData = ProductList.ToList()[0];//要審核的產品資料
                    string[] productCompanies = ProductReviewData.companyIdArr.Split(',');
                    #region 檢查邏輯
                    #region 3014 負責公司至少要有1個
                    if (ProductReviewData.companyIdArr != null && string.IsNullOrEmpty(ProductReviewData.companyIdArr.Trim()))
                    {
                        result.Code = "3014";//負責公司至少要有1個
                        return result;
                    }
                    #endregion
                    #region 4003 審核失敗，因為審核狀態已完成。
                    if (ProductReviewData.reviewStatus == 1)
                    {
                        result.Code = "4003";//審核失敗，因為審核狀態已完成。
                        return result;
                    }
                    #endregion
                    #region 2005 產品細項欄位重複了
                    var ProductToReview_Name2 = _repositoryWrapper.ProductData.FindByCondition(p => p.productName2 == ProductReviewData.productName2);
                    if (ProductToReview_Name2.Count() > 0)
                    {
                        result.Code = "2005";//產品細項欄位重複了
                        return result;
                    }
                    #endregion
                    #region 判斷是否AD存在 TO-DO
                    #endregion
                    #region 3013 新增產品的時候，有相對應的公司沒有供應商名字
                    var supplierList = _repositoryWrapper.SupplierData.FindByCondition(s => s.id == ProductReviewData.supplierName);
                    if (supplierList.Count() == 0)
                    {
                        result.Code = "3013";//新增產品的時候，有相對應的公司沒有供應商名字
                        return result;
                    }
                    #endregion
                    #endregion
                    #region 實際交易邏輯
                    switch (ProductReviewData.requestType)
                    {
                        case (int)ReviewType.Request:
                            #region 實際寫入新增
                            foreach (string company in productCompanies)
                            {
                                Product p = new Product(ProductReviewData);
                                if (p.ProductId == null)
                                {
                                    p.ProductId = pm.GetLatestProductId();
                                }
                                _repositoryWrapper.ProductData.Create(p);
                            }
                            #endregion
                            break;
                        case (int)ReviewType.Agree:
                            #region 判斷減少負責公司
                            // 產品減少負責公司時候：需判斷該負責公司的產品是否->
                            // 1.已經有開過訂單、雲端帳號使用了，都不可以減少
                            // 抓出該產品所要減少的公司資料
                            //    a.找出該 ProductId底下，所有隸屬公司的資料
                            var ProductToReview = _repositoryWrapper.ProductData.FindByCondition(p => p.ProductId == ProductReviewData.ProductId);
                            //    b.與該審核產品的companyIdArr比對CompanyId，如果存在就移除
                            string[] prodToReviewCompanies = ProductReviewData.companyIdArr.Split(',');
                            List<Product> ProductsCompany = ProductToReview.ToList();
                            foreach (string prodToReviewComp in prodToReviewCompanies)
                            {
                                int companyIdx = -1;
                                int idx = 0;
                                ProductsCompany.ForEach(p => {
                                    if (!string.IsNullOrEmpty(prodToReviewComp.Trim()) && p.companyId == int.Parse(prodToReviewComp.Trim()))
                                    {
                                        companyIdx = idx;//比對到負責的公司ID，記住其Index後跳出
                                        return;
                                    }
                                    idx++;
                                });
                                // 依據其負責的Index，由列表中移除該產品
                                if (companyIdx > 0)
                                {
                                    ProductsCompany.RemoveAt(companyIdx);
                                }
                            }
                            //    c.如果移除完了，ProductsCompany Length不為0，表示此次的審核，其負責公司有減少，需要再進一步判斷
                            int orderCloudUsedCount = 0;//有被訂單、雲端使用過的次數
                            ProductsCompany.ForEach(pp => {
                                //    c.1 判斷是否該產品、公司，已經開過訂單
                                var orderUsedList = pm.GetOrderUsedList((int)(pp.ProductId == null ? 0 : pp.ProductId), pp.companyId);
                                orderCloudUsedCount += orderUsedList.Count();//加總次數
                                                                             //    c.2 判斷是否該產品、公司，已經有雲端帳號
                                var cloudUsedList = pm.GetCloudUsedList((int)(pp.ProductId == null ? 0 : pp.ProductId), pp.companyId);
                                orderCloudUsedCount += cloudUsedList.Count();//加總次數
                            });
                            if (orderCloudUsedCount > 0)
                            {
                                result.Code = "3015";//無法申請減少產品的隸屬公司資料、因為已經被其他訂單或雲端帳號所使用。
                                return result;
                            }
                            #endregion
                            #region 資料存在的就更新，不存在的就Insert
                            foreach (string company in productCompanies)
                            {
                                Product p = new Product(ProductReviewData);
                                var nowProductData = _repositoryWrapper.ProductData.FindByCondition(p => p.ProductId == ProductReviewData.ProductId && p.companyId.ToString() == company);
                                if (nowProductData.Count() > 0)
                                {
                                    _repositoryWrapper.ProductData.Update(p);
                                }
                                else
                                {
                                    _repositoryWrapper.ProductData.Create(p);
                                }
                            }
                            #endregion
                            #region 如果有減少負責公司的Product就要刪除
                            foreach (Product productToRemove in ProductsCompany)
                            {
                                _repositoryWrapper.ProductData.Delete(productToRemove);
                            }
                            #endregion
                            break;
                        case (int)ReviewType.Reject:
                            #region 刪除產品-公司資料
                            foreach (string company in productCompanies)
                            {
                                var pDeleteList = _repositoryWrapper.ProductData.FindByCondition(p => p.ProductId == ProductReviewData.ProductId && p.companyId.ToString() == company);
                                if (pDeleteList.Count() > 0)
                                {
                                    foreach(Product pDelete in pDeleteList)
                                    {
                                        _repositoryWrapper.ProductData.Delete(pDelete);
                                    }
                                }
                            }
                            #endregion
                            break;
                    }
                    #region 更新ProductReview資料：狀態、原因、審核人員、日期
                    ProductReviewData.reviewStatus = reviewStatus;
                    ProductReviewData.DrawBackReason = reason;
                    ProductReviewData.reviewer = jwtObject.Id;
                    ProductReviewData.reviewDate = DateTime.Now;
                    _repositoryWrapper.ProductReviewData.Update(ProductReviewData);
                    #endregion
                    #endregion
                    result.Code = "0000";//成功
                    return result;
                }
                else
                {
                    #region 4011 審核失敗，該待審核產品資料不存在。
                    result.Code = "4011";//審核失敗，該待審核產品資料不存在。
                    return result;
                    #endregion
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
            }
            return result;
        }
        //public ApiResult<>
    }
}
