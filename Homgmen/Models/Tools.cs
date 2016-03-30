using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homgmen.Models
{
    public static class Tools
    {
        /// <summary>
        /// 从数据列表转换为XML字符串
        /// </summary>
        /// <param name="listsothm">运单数据列表</param>
        /// <param name="flag">单据状态</param>
        /// <returns>转换成功的XML字符串</returns>
        public static string WriteReceiveinfoXml(List<sothm> listsothm, int flag)
        {
            //提交数据模板XML文件头
            string receiveinfoXmlFileHead = "<?xml version =\"1.0\" encoding=\"utf-8\"?><message><field-table name=\"receiveinfo\">{0}</field-table></message>";
            //提交数据模板XML数据行
            string receiveinfoXmlRowHead = "<field-row name=\"{0}\">{1}</field-row>";
            //Xml数据模板行
            string receiveinfoXmlRow = "<field name=\"receive_code\">{0}</field><field name=\"goods_code\">{1}</field><field name=\"old_code\">{2}</field><field name=\"send_man\">{3}</field><field name=\"send_tel\">{4}</field><field name=\"receive_man\">{5}</field><field name=\"receive_tel\">{6}</field><field name=\"transit_code\">1112</field><field name=\"state\">{7}</field><field name=\"payed_money\">{8}</field><field name=\"arrive_pay\">{9}</field><field name=\"owe_pay\" >{10}</field><field name=\"month_pay\">{11}</field><field name=\"mat_traffic\">{12}</field><field name=\"rtgets_goods\">{13}</field><field name=\"gets_goods\">{14}</field><field name=\"datetime\">{15}</field><field name=\"loan_code\">0</field><field name=\"loan_gain\">0</field><field name=\"group_code\">504</field><field name=\"targetgroup_code\">0</field><field name=\"logdate\" >{16}</field><field name=\"loggroup_code\">0</field><field name=\"loan_type\">0</field>";

            //数据，行xml模板字符串
            string tempdataXml, temprowxml = String.Empty;
            //数据行数
            int rownumber = 0;
            //循环处理条目
            foreach (var item in listsothm)
            {
                //单据行内提付，现付，月结，回执中间变量
                Decimal tifu, xianfu, yuejie, huizhi = 0;
                //付款方式调整
                string fkfs = item.付款方式.ToString().Trim();
                switch (fkfs)
                {
                    case "现付":
                        tifu = 0;
                        xianfu = Convert.ToDecimal(item.运费);
                        yuejie = 0;
                        huizhi = 0;
                        break;
                    case "月结":
                        tifu = 0;
                        xianfu = 0;
                        yuejie = Convert.ToDecimal(item.运费);
                        huizhi = 0;
                        break;
                    case "回执":
                        tifu = 0;
                        xianfu = 0;
                        yuejie = 0;
                        huizhi = Convert.ToDecimal(item.运费);
                        break;
                    default:
                        tifu = Convert.ToDecimal(item.运费);
                        xianfu = 0;
                        yuejie = 0;
                        huizhi = 0;
                        break;
                }
                tempdataXml = String.Format(receiveinfoXmlRow,                      //数据行模板
                                            "504" + item.ID.ToString().Trim(),      //运单号码，"504"为大红门集团规定的代号
                                            "504" + item.ID.ToString().Trim(),      //运单号码，"504"为大红门集团规定的代号
                                            "504" + item.ID.ToString().Trim(),      //运单号码，"504"为大红门集团规定的代号
                                            item.发货人.ToString().Trim(),          //发货人
                                            item.发货人电话.ToString().Trim(),      //发货人电话 
                                            item.收货人.ToString().Trim(),          //收货人
                                            item.收货人电话.ToString().Trim(),      //收货人电话 
                                            flag.ToString().Trim(),                 //单据状态 
                                            xianfu.ToString().Trim(),               //现付
                                            tifu.ToString().Trim(),                 //提付
                                            huizhi.ToString().Trim(),               //回执
                                            yuejie.ToString().Trim(),               //月结
                                            item.垫付款.ToString().Trim(),          //垫付款
                                            item.代收金额.ToString().Trim(),        //代收金额
                                            item.代收金额.ToString().Trim(),        //实收代收金额
                                            item.时间.ToString().Trim(),            //运单发生时间
                                            DateTime.Now.ToString().Trim());        //当前操作时间
                //数据行xml生成
                temprowxml = temprowxml + String.Format(receiveinfoXmlRowHead, rownumber.ToString().Trim(), tempdataXml);
                rownumber++;
            }

            return String.Format(receiveinfoXmlFileHead, temprowxml);
        }

        /// <summary>
        /// 从字符串运单号列表转换为运单对象列表
        /// </summary>
        /// <param name="danhaolist">以","分割的运单号集合</param>
        /// <returns>运单对象列表</returns>
        public static List<sothm> StringDanHaoToDataDanhaoList(string danhaolist)
        {
            //返回数据列表
            List<sothm> ResultSothmList = new List<sothm>();
            NewSot newsot = new NewSot();
            //将字符串转换为字符串列表
            List<string> dhlist = new List<string>();
            dhlist.AddRange(danhaolist.Split(",".ToCharArray()));
            //将单据对象添加到单据对象列表
            foreach(string item in dhlist)
            {
                sothm sothm = newsot.sothms.Find(Convert.ToInt64(item));
                ResultSothmList.Add(sothm);
            }
            //返回单据对象列表
            return ResultSothmList;
        }
    }
}