using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models.Accounting;
using DataCentre.Api.Entity.Models.Generic;
using DataCentre.Api.Entity.Models.Product;
using DataCentre.Api.Module;
using DataCentre.Api.View;

namespace DataCentre.Api.Module.Product
{
    //Middleware-like class to process ProductController
    public class ProductModule : ModuleBase
    {
        //private static IRepositoryWrapper _repositoryWrapper;
        public ProductModule(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
        {
            
        }
        public ProductMainView GetProductMainView()
        {
            ProductMainView MainView = new ProductMainView();
            // init
            MainView.productClassArray = new List<CommonType>();
            MainView.productTypeArray = new List<CommonType>();
            MainView.companyArray = new List<CommonType>();
            MainView.departmentArray = new List<CommonType>();
            MainView.accountingArray = new List<CommonType>();
            MainView.accountingBranch = new List<CommonType>();
            MainView.accountingProductType = new List<CommonType>();
            // 產品別項目
            var prodtype = _repositoryWrapper.ProductTypeData.findAll();
            foreach (DataCentre.Api.Entity.Models.Product.ProductType ProductType in prodtype)
            {
                CommonType ProductType_1 = new CommonType();
                ProductType_1.id = ProductType.ProductTypeId;
                ProductType_1.name = ProductType.ProductTypeName;
                MainView.productTypeArray.Add(ProductType_1);
            }
            // 產品類項目
            var prodclass = _repositoryWrapper.ProductClassData.findAll();
            foreach (ProductClass pc in prodclass)
            {
                CommonType ProductClass_1 = new CommonType();
                ProductClass_1.id = pc.ProductClassId;
                ProductClass_1.name = pc.ProductClassName;
                MainView.productClassArray.Add(ProductClass_1);
            }
            // 我的公司選項
            var company = _repositoryWrapper.CompanyData.findAll();
            foreach (Company c in company)
            {
                CommonType c1 = new CommonType();
                c1.id = c.ID;
                c1.name = c.Name;
                MainView.companyArray.Add(c1);
            }
            // 公司單位選項
            var companyUnit = _repositoryWrapper.CompanyUnitData.findAll();
            foreach (CompanyUnit c in companyUnit)
            {
                CommonType c1 = new CommonType();
                c1.id = c.ID;
                c1.name = c.Name;
                MainView.departmentArray.Add(c1);
            }
            // 會計科目選項
            var accounting = _repositoryWrapper.AccountItemData.findAll();
            foreach (AccountingItem c in accounting)
            {
                CommonType c1 = new CommonType();
                c1.id = c.AccountingItemId;
                c1.name = c.AccountingItemCode + " " + c.AccountingItemName;
                MainView.accountingArray.Add(c1);
            }
            // 會計子目選項
            var accountingBranch = _repositoryWrapper.AccountSubItemData.findAll();
            foreach (AccountingSubItem c in accountingBranch)
            {
                CommonType c1 = new CommonType();
                c1.id = c.AccountingSubItemId;
                c1.name = c.AccountingSubItemCode + " " + c.AccountingSubItemName;
                MainView.accountingBranch.Add(c1);
            }
            // 會計產品別選項
            var accountingProdType = _repositoryWrapper.AccountProdTypeData.findAll();
            foreach (AccountingProductType c in accountingProdType)
            {
                CommonType c1 = new CommonType();
                c1.id = c.AccountingProductTypeId;
                c1.name = c.AccountingProductTypeCode + " " + c.AccountingProductTypeName;
                MainView.accountingProductType.Add(c1);
            }
            return MainView;
        }

        public List<Entity.Models.Product.Product> GetProductConditionList(int? productTypeId, string? productName1, string? productName2, int? personInChargeName, string? supplierName)
        {
            List<Entity.Models.Product.Product> prodList = new List<Entity.Models.Product.Product>();
            if(productTypeId != null)
            {
                prodList = _repositoryWrapper.ProductData.FindByCondition(Product => Product.productClassId.Equals(productTypeId)).ToList();
            }
            if(!string.IsNullOrEmpty(productName1))
            {
                prodList = _repositoryWrapper.ProductData.FindByCondition(Product => productName1 != null && Product.productName1 != null && Product.productName1.Equals(productName1)).ToList();
            }
            if (!string.IsNullOrEmpty(productName2))
            {
                prodList = _repositoryWrapper.ProductData.FindByCondition(Product => productName2 != null && Product.productName2 != null && Product.productName2.Equals(productName2)).ToList();
            }
            if (personInChargeName != null)
            {
                prodList = _repositoryWrapper.ProductData.FindByCondition(Product => productName2 != null && Product.personInChargeId.Equals(personInChargeName)).ToList();
            }
            if (supplierName != null)
            {
                prodList = _repositoryWrapper.ProductData.FindByCondition(Product => productName2 != null && Product.supplierName.Equals(supplierName)).ToList();
            }
            return prodList;
        }

        public bool GetProductname2Dup(string productName2)
        {
            var list = _repositoryWrapper.ProductData.FindByCondition(p => p.productName2 == productName2);
            if (list.Count() > 0)
                return true;
            return false;
        }


        public int GetLatestProductId()
        {
            //throw new NotImplementedException();
            int productId = 0;
            //var list = _repositoryWrapper.ProductData.Query("")
            //IdbConnection conn = _repositoryWrapper.ProductData.GetRepositoryContext().CreateConnection();
            var list = _repositoryWrapper.ProductData.findAll().OrderByDescending(p => p.id);
            if(list.Count() > 0)
            {
                if (list.ToList()[0].ProductId != null)
                {
                    productId = (int)(list.ToList()[0].ProductId) + 1;
                }
                else
                {
                    throw new Exception("產生ProductId異常");
                }
            }
            return productId;
        }

        public DataCentre.Api.Entity.Models.Product.Product? GetProductView(string? _productName2)
        {
            var prod = _repositoryWrapper.ProductData.FindByCondition(product => product != null && product.productName2 != null && product.productName2.Equals(_productName2));
            DataCentre.Api.Entity.Models.Product.Product prodView = new DataCentre.Api.Entity.Models.Product.Product();
            if (prod.Count() > 0)
            {
                prodView = prod.ToList()[0];
            }
            return prodView;
        }

        public List<CommonType> GetProductName2List(string productName)
        {
            List <CommonType>  commTypes = new List<CommonType>();
            var prodname2 = _repositoryWrapper.ProductData.FindByCondition(name => name != null && name.productName2 != null && name.productName2.Equals(productName));
            foreach (DataCentre.Api.Entity.Models.Product.Product c in prodname2)
            {
                CommonType c1 = new CommonType();
                c1.name = string.IsNullOrEmpty(c.productName2) ? "" : c.productName2;
                commTypes.Add(c1);
            }
            return commTypes;
        }

        public List<CommonType> GetProductNameList()
        {
            List<CommonType> commonTypes = new List<CommonType>();
            var prod = from s in _repositoryWrapper.ProductData.findAll()
                       select s;
            foreach (DataCentre.Api.Entity.Models.Product.Product c in prod)
            {
                CommonType c1 = new CommonType();
                c1.id = c.id;
                c1.name = string.IsNullOrEmpty(c.productName1) ? "" : c.productName1;
                commonTypes.Add(c1);
            }
            return commonTypes;
        }

        public List<object> GetOrderUsedList(int productId, int companyId)
        {
            throw new NotImplementedException();
        }

        public List<object> GetCloudUsedList(int productId, int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
