using DataCentre.Api.Entity.Models;
using DataCentre.Api.Module;

namespace DataCentre.Api.View
{
    public class HomeView : ResultView
    {
        public List<Notification> notify { get; set; }
    }
}
