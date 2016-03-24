using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homgmen.Models
{
    /// <summary>
    /// 将数据列表转换成XML格式
    /// </summary>
    public class DataToXml
    {
        //空白代收信息数据XML模板
        string LoaninfoXml = "<?xml version =\"1.0\" encoding = \"utf-8\" ?><message><field-table name = \"loaninfo\"><field-row name = \"0\"><field name = \"loan_code\"></field><field name = \"loan_date\"></field><field name = \"get_cardnum\"></field><field name = \"goods_money\" ></field><field name = \"loan_gain\"></field><field name = \"loan_money\"></field><field name = \"ticket_cnt\"></field><field name = \"receive_code\"></field><field name = \"transit_code\"></field><field name = \"group_code\"></field><field name = \"bank\"></field><field name = \"get_people\"></field></field-row></field-table></message>";
        
        //数据列表
        private List<sothm> datalist;

        public DataToXml(List<sothm> data)
        {
            datalist = data;
        }

        /// <summary>
        /// 将数据列表转换为大红门集团给定的XML文件格式
        /// </summary>
        /// <param name="flag">单据状态.10-发货,30-到货,40-付款提货,50-已回已放,60-原返或取消</param>
        /// <returns></returns>
        public int ConvertToXml(int flag)
        {
            //定义每页数据的数据条目数
            const int PageSize = 150;
            //当前数据页数
            int CurrentPage = 0;
            //总数据条目
            int count = datalist.Count();

            while (CurrentPage * PageSize < count )
            {
                //因大红门系统服务器限制，大于200条单据上传有问题，所以将每页数据条目限制为150条
                //先将数据列表按照时间进行排序，然后按照页数及每页数据条目进行切分进行转换
                BlockConvertToXml(datalist.OrderBy(item => item.时间).Skip(CurrentPage * PageSize).Take(PageSize).ToList(), flag);
                CurrentPage++; 
            }
            //返回转换的数据条目
            return count;
        }

        /// <summary>
        /// 分块转换数据条目为XML格式
        /// </summary>
        /// <param name="listsothm">分块后的数据列表</param>
        /// <param name="flag">单据状态</param>
        private void BlockConvertToXml(List<sothm> listsothm, int flag)
        {
            //运单信息XML字符串初始化
            string mainXml = WriteDataXml(listsothm, flag);
        }

        /// <summary>
        /// 从数据列表转换为XML字符串
        /// </summary>
        /// <param name="listsothm">运单数据列表</param>
        /// <param name="flag">单据状态</param>
        /// <returns>转换成功的XML字符串</returns>
        private string WriteDataXml(List<sothm> listsothm, int flag)
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
            foreach(var item in listsothm)
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
                                            DateTime.Now.ToString().Trim());          //当前操作时间
                //数据行xml生成
                temprowxml = temprowxml + String.Format(receiveinfoXmlRowHead, rownumber.ToString().Trim(), tempdataXml);
                rownumber++;
            }

            return String.Format(receiveinfoXmlFileHead, temprowxml);
        }
    }
}