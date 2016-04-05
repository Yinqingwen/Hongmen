using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homgmen.Models;

namespace Homgmen.Controllers
{
    public class SettingController : Controller
    {
        /// <summary>
        /// iPad单据数据库，IP地址为182.92.174.109，库名：adtic
        /// </summary>
        private OldSot oldsot = new OldSot();

        /// <summary>
        /// 提交用数据库，IP地址为182.92.174.109，库名：newsot
        /// </summary>
        private NewSot newsot = new NewSot();
 
        // GET: Setting
        public ActionResult Index()
        {
            ViewBag.iPadCount = oldsot.Iddes.Count().ToString().Trim();
            return View();
        }

        public ActionResult iPad()
        {
            var data = oldsot.Iddes.Where(item => item.完成度 == "2").OrderBy(item => item.设备号).ToList();
            return View(data);
        }
    }
}