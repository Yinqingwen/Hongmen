﻿using System.Web.Mvc;

namespace Homgmen.Areas.Setting
{
    public class SettingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Setting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Setting_default",
                "Setting/{controller}/{action}/{id}",
                new 
                { 
                    controller = "Setting",
                    action = "Index", 
                    id = UrlParameter.Optional,
                }
            );
        }
    }
}