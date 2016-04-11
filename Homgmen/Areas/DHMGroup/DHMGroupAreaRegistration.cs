using System.Web.Mvc;

namespace Homgmen.Areas.DHMGroup
{
    public class DHMGroupAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DHMGroup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DHMGroup_default",
                "DHMGroup/{controller}/{action}/{id}",
                new 
                {
                    controller = "Site",
                    action = "Index", 
                    id = UrlParameter.Optional 
                }
            );
        }
    }
}