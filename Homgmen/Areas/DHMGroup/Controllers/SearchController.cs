using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homgmen.Models;

namespace Homgmen.Areas.DHMGroup.Controllers
{
    public class SearchController : Controller
    {
        /// <summary>
        /// 上传运单数据库
        /// </summary>
        private NewSot newdb = new NewSot();

        // GET: DHMGroup/Search
        public ActionResult Yundan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yundan(long YdNumber)
        {
            var data = newdb.sothms.Find(YdNumber);

            return View(data);
        }
    }
}