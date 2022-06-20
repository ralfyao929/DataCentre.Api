using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models.Product;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models;
using DataCentre.Api.Module;
using DataCentre.Api.View;
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
        public ApiResult<ProductMainView> Get()
        {
            ApiResult<ProductMainView> result = new ApiResult<ProductMainView>(_localizer.GetValue<string>("AppSettings:localize"));
            try
            {
                ProductMainView MainView = new ProductMainView();
                //產品別項目
                var prodtype = _repositoryWrapper.ProductTypeData.findAll();
                MainView.productTypeArray = new List<CommonType>();
                foreach (DataCentre.Api.Entity.Models.Product.ProductType ProductType in prodtype) 
                {
                    CommonType ProductType_1 = new CommonType();
                    ProductType_1.id = ProductType.ProductTypeId;
                    ProductType_1.name = ProductType.ProductTypeName;
                    MainView.productTypeArray.Add(ProductType_1);
                }
                //產品類項目
                var prodclass = _repositoryWrapper.ProductClassData.findAll();
                MainView.productClassArray = new List<CommonType>();
                foreach(ProductClass pc in prodclass) 
                {
                    CommonType ProductClass_1 = new CommonType();
                    ProductClass_1.id = pc.ProductClassId;
                    ProductClass_1.name = pc.ProductClassName;
                    MainView.productTypeArray.Add(ProductClass_1);
                }
                //我的公司選項

            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
