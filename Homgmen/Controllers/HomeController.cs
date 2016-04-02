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
            return View();
        }

        public ActionResult Index1()
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
        /// 从日期型转换为字符串型，OldSot用
        /// </summary>
        /// <param name="date">日期型数据</param>
        /// <returns>字符串型日期数据</returns>
        private string datetostring(DateTime date)
        {
            return string.Format("{0}-{1}-{2}", date.Year.ToString().Trim(),date.Month.ToString().Trim(),date.Day.ToString().Trim());
        }

        /// <summary>
        /// 根据日期删除数据库中的相关条目
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
        /// 获取应提交的数据条目数量
        /// </summary>
        /// <returns></returns>
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
            //将当前日期的新数据库中的数据条目清除
            ClearSothmForDate(DateTime.Today.Date);

            //将当前日期转换为字符串类型，旧数据库用
            string rq = datetostring(DateTime.Today);
            //数据列表
            var data = oldsot.Sots.Where(item => item.收货网点 == "大红门").Where(item => item.托运日期 == rq).Where(item => item.完成度 == "2").ToList();
            //数据条目
            int count = data.Count();
            //开始同步数据
            foreach(var dataitem in data)
            {
                sothm sothm = new sothm(dataitem);
                sothm.单据状态 = 10;
                sothm.上传状态 = false;
                newsot.sothms.Add(sothm);
            }
            newsot.SaveChanges();

            return Content(count.ToString());
        }

        /// <summary>
        /// 向大红门集团上报数据
        /// </summary>
        /// <returns>上报的数据条目</returns>
        public ActionResult UploadData()
        {
            //当前日期
            DateTime current = DateTime.Today.Date;
            //获取当天，单据状态为10，上传状态 = false的运单数据
            var data = newsot.sothms.Where(item => item.托运日期 == current).Where(item => item.单据状态 == 10).Where(item => item.上传状态 == false).ToList();
            //运单总数
            int count = data.Count();
            //将运单列表转换为XML
            DataToXml dtm = new DataToXml(data);
            dtm.ConvertToXml(10);

            //将数据列表中的数据全部设置为上传状态为True
            foreach(var dataitem in data)
            {
                dataitem.上传状态 = true;
            }
            newsot.SaveChanges();

            return Content(count.ToString());
        }

        /// <summary>
        /// 获取当日发货代收金额
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDSJine()
        {
            //当前日期
            DateTime current = DateTime.Today.Date;
            //获取当日发货代收金额数量
            decimal je = Convert.ToDecimal(newsot.sothms.Where(item => item.托运日期 == current).Where(item => item.代收金额 > 0).Sum(item => item.代收金额));

            return Content(je.ToString());
        }

        /// <summary>
        /// 获取今日到货单据并上传大红门集团
        /// 检索条件为：托运日期为今日-1，且单据状态为10，上传状态为1
        /// </summary>
        /// <returns>到货单据数量</returns>
        public ActionResult UploadDH()
        {
            //获取日期，条件为当日-1
            DateTime current = DateTime.Today.AddDays(-1).Date;
            //获取到货数据集及数量
            var data = newsot.sothms.Where(item => item.托运日期 == current).Where(item => item.单据状态 == 10).Where(item => item.上传状态 == true).ToList();
            int count = data.Count;
            //转换为XML文件并上传大红门集团
            DataToXml dtm = new DataToXml(data);
            dtm.ConvertToXml(30);

            //修改单据状态为30，并保存
            foreach(var item in data)
            {
                item.单据状态 = 30;
            }
            //发布时，需要保存
            //newsot.SaveChanges();

            //返回
            return Content(count.ToString());
        }

        /// <summary>
        /// 获取当日汇款单据数量并上报大红门集团
        /// </summary>
        /// <returns>汇款单据数量</returns>
        public ActionResult UploadFK()
        {
            //获取数据结果集
            var data = newsot.hmdshzs.Where(item => item.上传状态 == false).ToList();
            HkdjTOXml hkdj = new HkdjTOXml(data);
            //返回数量结果
            return Content(hkdj.ConvertToXML());
        }
    }
}