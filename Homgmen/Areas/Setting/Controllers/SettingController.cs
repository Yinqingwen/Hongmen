using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homgmen.Models;

namespace Homgmen.Areas.Setting.Controllers
{
    public class SettingController : Controller
    {
        /// <summary>
        /// iPad单据数据库，IP地址为182.92.174.109，库名：adtic
        /// </summary>
        private OldSot oldsot = new OldSot();

        // GET: Setting/Setting
        public ActionResult Index()
        {
            ViewBag.iPadCount = oldsot.Iddes.Where(item => item.完成度 == "2").Count();
            ViewBag.SiteCount = oldsot.Citytels.Where(item => item.完成度 == "2").Count();
            return View();
        }
    }
}