using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homgmen.Models;

namespace Homgmen.Controllers
{
    public class SiteController : Controller
    {
        /// <summary>
        /// iPad单据数据库，IP地址为182.92.174.109，库名：adtic
        /// </summary>
        private OldSot oldsot = new OldSot();

        /// <summary>
        /// 提交用数据库，IP地址为182.92.174.109，库名：newsot
        /// </summary>
        private NewSot newsot = new NewSot();

        // GET: Site
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            //当前日期，旧数据库用
            string currentdate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            //应提交的到货单据日期，为当前日期-1
            DateTime dhriqi = DateTime.Now.AddDays(-1).Date;

            //获取iPad数据库中，发货站点为大红门，运单完成度为'2'的运单数量
            ViewBag.TotalDataCount = oldsot.Sots.Where(item => item.收货网点 == "大红门").Where(item => item.托运日期 == currentdate).Where(item => item.完成度 == "2").Count();
            //获取今日应提交的到货单据数量
            ViewBag.DHDataCount = newsot.sothms.Where(item => item.托运日期 == dhriqi).Where(item => item.单据状态 == 10).Where(item => item.上传状态 == true).Count();
            //获取今日应提交的汇款单据数量
            ViewBag.DSCount = newsot.hmdshzs.Where(item => item.上传状态 == false).Count();
            return View();
        }
    }
}