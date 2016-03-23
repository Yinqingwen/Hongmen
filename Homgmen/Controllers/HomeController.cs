using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homgmen.Models;

namespace Homgmen.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// iPad单据数据库，IP地址为182.92.174.109，库名：adtic
        /// </summary>
        private OldSot oldsot = new OldSot();

        /// <summary>
        /// 提交用数据库，IP地址为182.92.174.109，库名：newsot
        /// </summary>
        private NewSot newsot = new NewSot();

        public ActionResult Index()
        {
            //当前日期，旧数据库用
            string currentdate = DateTime.Now.Year.ToString()+"-"+DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString();
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 从日期型转换为字符串型
        /// </summary>
        /// <param name="date">日期型数据</param>
        /// <returns>字符串型日期数据</returns>
        private string datetostring(DateTime date)
        {
            return string.Format("{0}-{1}-{2}", date.Year.ToString().Trim(),date.Month.ToString().Trim(),date.Day.ToString().Trim());
        }

        /// <summary>
        /// 根据日期删除数据库
        /// </summary>
        /// <param name="date">需要删除的日期</param>
        private void ClearSothmForDate(DateTime date)
        {
            //检索现有数据库，如有传入日期值的，先删除掉，防止重复
            var data = newsot.sothms.Where(item => item.托运日期 == date);
            int count = data.Count();
            if (count > 0)
            {
                foreach (var dateitem in data)
                    newsot.sothms.Remove(dateitem);
                newsot.SaveChanges();
            }
        }

        /// <summary>
        /// 将iPad运单数据同步到准备数据库中
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private int GetData(DateTime date)
        {
            //同步的数据数量
            int count;
            //清除当前日期的数据
            ClearSothmForDate(date);

            //检索旧数据库，创建数据对象
            string sdate = datetostring(date);
            var olddata = oldsot.Sots.Where(item => item.收货网点 == "大红门").Where(item => item.托运日期 == sdate).Where(item => item.完成度 == "2");
            count = olddata.Count();
            foreach (var olddataitem in olddata)
            {
                sothm sothm = new sothm(olddataitem);
                newsot.sothms.Add(sothm);
            }
            newsot.SaveChanges();
            return count;
        }

        public ActionResult ReadyData()
        {
            string rq = datetostring(DateTime.Today);
            int count = oldsot.Sots.Where(item => item.收货网点 == "大红门").Where(item => item.托运日期 == rq).Where(item => item.完成度 == "2").Count();
            return Content(count.ToString());
        }

        /// <summary>
        /// 同步需要上传的数据，adtic.sot -> newsot.sothm
        /// </summary>
        /// <returns>同步的数据条目</returns>
        public ActionResult SyncData()
        {
            int count;
            return Content("ok");
        }

        [HttpPost]
        public ActionResult SyncData(DateTime id)
        {
            return Content("ok");
        }
    }
}