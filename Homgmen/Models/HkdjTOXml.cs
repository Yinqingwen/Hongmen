using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homgmen.Models
{
    /// <summary>
    /// 汇款单据类转换为大红门系统规定的XML文件,并且上传到大红门集团服务器
    /// </summary>
    public class HkdjTOXml
    {
        //数据库对象
        private NewSot newsot = new NewSot();
        //内部代收汇款单据对象
        private List<hmdshz> _hmdshzlist;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hmdshz">外部传入的代收汇款单据对象</param>
        public HkdjTOXml(List<hmdshz> hmdshzlist)
        {
            _hmdshzlist = hmdshzlist;
        }

        /// <summary>
        /// 将汇款单据及相关运单数据转换为XML文件并上传到大红门集团
        /// </summary>
        /// <returns></returns>
        public string ConvertToXML()
        {
            foreach(hmdshz item in _hmdshzlist)
            {
                //获取运单XML
                string ReceiveinfoXml = GetReceiveinfoXml(item);
                //获取汇款XML
                string LoaninfoXml = GetLoaninfoXml(item);
                //上传XML
                UploadToDHM.UploadXml(ReceiveinfoXml, LoaninfoXml);
            }

            return (_hmdshzlist.Count.ToString());
        }

        /// <summary>
        /// 检验汇款单据中的运单号
        /// 单张运单号不存在删除汇款单
        /// 多张运单号不存在修改相关汇款单内容
        /// </summary>
        /// <param name="item">汇款单据对象</param>
        private void VaildReceive(hmdshz item)
        {
            //经过检测的运单数量
            int count = 0;
            //经过检测运单号列表
            List<string> danhaolist = new List<string>();
            //经过检测的实际代收款金额
            Decimal JinE = 0.00M;

            //开始检验运单号
            List<string> templist = new List<string>();
            templist.AddRange(item.收货编号集合.Trim().Split(",".ToCharArray()));
            //循环校验运单列表，并修改中间变量
            foreach (string danhao in templist)
            {
                var dj = newsot.sothms.Find(Convert.ToInt64(danhao));
                if (dj != null)
                {
                    count++;
                    danhaolist.Add(danhao);
                    JinE += Convert.ToDecimal(dj.代收金额);
                }
            }
            
            if (count == 0)
            {
                //有效运单数量为零
                hmdshz dada = newsot.hmdshzs.Find(item.id);
                //删除汇款单据
                newsot.hmdshzs.Remove(dada);
                //数据库保存
                newsot.SaveChanges();
            }
            else if (item.放款票据份数 != count)
            {
                //有效单据数量与汇款单中的运单数量不符，修改汇款单数据
                hmdshz dada = newsot.hmdshzs.Find(item.id);
                dada.放款票据份数 = count;
                dada.实收货款 = JinE;
                dada.始发代收货款 = JinE;
                dada.收货编号集合 = string.Join(",", danhaolist.ToArray());
                newsot.SaveChanges();
            }
        }

        private string GetReceiveinfoXml(hmdshz item)
        {
            //返回的XML字符串
            string resultxml = string.Empty;
            //校验汇款单据中的运单
            VaildReceive(item);
            List<sothm> sothmlist = Tools.StringDanHaoToDataDanhaoList(item.收货编号集合);
            resultxml = Tools.WriteReceiveinfoXml(sothmlist, 50);

            return resultxml;
        }

        private string GetLoaninfoXml(hmdshz item)
        {
            //返回的LoaninfoXML字符串
            string resultxml = string.Empty;

            //代收XML文件头模板
            string LoaninfoXmlHead = "<?xml version =\"1.0\" encoding = \"utf-8\" ?><message><field-table name = \"loaninfo\">{0}</field-table></message>";
            //代收XML文件行模板
            string LoaninfoXmlRow = "<field-row name = \"{0}\">{1}</field-row>";
            //代收XML文件行数据模板
            string LoaninfoXml = "<field name = \"loan_code\">{0}</field><field name = \"loan_date\">{1}</field><field name = \"get_cardnum\">{2}</field><field name = \"goods_money\">{3}</field><field name = \"loan_gain\">{4}</field><field name = \"loan_money\">{5}</field><field name = \"ticket_cnt\">{6}</field><field name = \"receive_code\">{7}</field><field name = \"transit_code\">{8}</field><field name = \"group_code\">{9}</field><field name = \"bank\">{10}</field><field name = \"get_people\">{11}</field>";

            int row = 0;
            string rowtempxml = "";
            string rowdatatempxml = String.Format(LoaninfoXml, 
                                                    item.结算单号.ToString().Trim(), 
                                                    item.放款时间.ToString().Trim(), 
                                                    item.银行卡号.ToString().Trim(), 
                                                    item.实收货款.ToString().Trim(), 
                                                    item.放款手续费.ToString().Trim(), 
                                                    item.始发代收货款.ToString().Trim(), 
                                                    item.放款票据份数.ToString().Trim(), 
                                                    item.收货编号集合.ToString().Trim(), 
                                                    item.物流公司编号.ToString().Trim(), 
                                                    item.放款站点编号.ToString().Trim(), 
                                                    item.放款银行编号.ToString().Trim(), 
                                                    item.持卡人姓名.ToString().Trim());
            rowtempxml = rowtempxml + String.Format(LoaninfoXmlRow, row.ToString().Trim(), rowdatatempxml);
            string tempxml = String.Format(LoaninfoXmlHead, rowtempxml);

            return resultxml;
        }
    }
}