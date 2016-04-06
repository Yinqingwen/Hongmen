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

        [HttpGet]
        public ActionResult iPad()
        {
            var data = oldsot.Iddes.Where(item => item.完成度 == "2").OrderBy(item => item.设备号).ToList();
            return View(data);
        }

        [HttpPost]
        [ActionName("iPad")]
        public ActionResult iPadAdd()
        {
            Idde idde = new Idde();
            idde.设备号 = Request["SerialNumber"].ToString().Trim();
            idde.业务员 = Request["Yewuyuan"].ToString().Trim();
            idde.收货网点 = Request["Site"].ToString().Trim();
            idde.始发城市 = Request["City"].ToString().Trim();
            idde.责任人 = Request["Zeren"].ToString().Trim();
            idde.完成度 = "2";
            oldsot.Iddes.Add(idde);
            oldsot.SaveChanges();
            return RedirectToAction("iPad");
        }

        [HttpGet]
        public ActionResult iPadEdit(int? id)
        {
            Idde data;

            if (id != null && id != 0)
            {
                data = oldsot.Iddes.Find(id);
                return View(data);
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult iPadEditUpdate(int? id)
        {
            Idde data;

            if (id != null && id != 0)
            {
                data = oldsot.Iddes.Find(id);
                data.设备号 = Request["SerialNumber"].ToString().Trim();
                data.业务员 = Request["Yewuyuan"].ToString().Trim();
                data.收货网点 = Request["Site"].ToString().Trim();
                data.始发城市 = Request["City"].ToString().Trim();
                data.责任人 = Request["Zeren"].ToString().Trim();
                oldsot.SaveChanges();
            }
            
            return RedirectToAction("iPad");
        }

        public ActionResult iPadDelete(int? id)
        {
            Idde data;

            if (id != null && id != 0)
            {
                data = oldsot.Iddes.Find(id);
                if (data != null)
                    oldsot.Iddes.Remove(data);
            }
            oldsot.SaveChanges();

            return RedirectToAction("iPad");
        }
    }
}