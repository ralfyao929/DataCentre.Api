using DataCentre.Api.Module;
using DataCentre.Api.View;

namespace DataCentre.Api.View
{
    public class ProductMainView : ResultView
    {
        public List<CommonType> productTypeArray { get; set; }
        public List<CommonType> productClassArray { get; set; }
    }
}
