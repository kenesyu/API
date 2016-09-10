using System.Web.Mvc;

namespace WebApi.Areas.Trading
{
    public class TradingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Trading";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Trading_default",
                "Trading/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
