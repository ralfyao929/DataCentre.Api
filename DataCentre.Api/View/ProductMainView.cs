using DataCentre.Api.Module;
using DataCentre.Api.View;

namespace DataCentre.Api.View
{
    public class ProductMainView : ResultView
    {
        public List<CommonType> productName { get; set; }
        public List<CommonType> productName2 { get; set; }
        public List<CommonType> productTypeArray { get; set; }
        public List<CommonType> productClassArray { get; set; }
        public List<CommonType> companyArray { get; set; }
        public List<CommonType> departmentArray { get; set; }
        public List<CommonType> accountingArray { get; set; }
        public List<CommonType> accountingBranch { get; set; }
        public List<CommonType> accountingProductType { get; set; }
    }
}
