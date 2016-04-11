﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homgmen.Models;

namespace Homgmen.Areas.DHMGroup.Controllers
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

        // GET: DHMGroup/Site
        public ActionResult Index()
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

        /// <summary>
        /// 获取应提交的数据条目数量
        /// </summary>
        /// <returns>数据条目</returns>
        public ActionResult ReadyData()
        {
            string rq = datetostring(DateTime.Today);
            int count = oldsot.Sots.Where(item => item.收货网点 == "大红门").Where(item => item.托运日期 == rq).Where(item => item.完成度 == "2").Count();
            return Content(count.ToString());
        }

        /// <summary>
        /// 从日期型转换为字符串型，OldSot用
        /// </summary>
        /// <param name="date">日期型数据</param>
        /// <returns>字符串型日期数据</returns>
        private string datetostring(DateTime date)
        {
            return string.Format("{0}-{1}-{2}", date.Year.ToString().Trim(), date.Month.ToString().Trim(), date.Day.ToString().Trim());
        }
    }
}