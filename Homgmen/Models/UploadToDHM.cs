using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homgmen.WebReference;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Homgmen.Models
{
    public static class UploadToDHM
    {
        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 按照上传时间，将操作文件保存，备查
        /// </summary>
        /// <param name="receiveinfoxml">票据信息XML字符串</param>
        /// <param name="loaninfoxml">代收信息XML字符串</param>
        /// <returns></returns>
        private static void FileSaveBackup(string receiveinfoxml, string loaninfoxml)
        {
            //在FileBackup目录下按照当前日期创建目录
            string dirname = DateTime.Now.ToString("yyyyMMdd");
            dirname = System.Web.HttpContext.Current.Server.MapPath(@"~/FileBackup") + @"\" + dirname;
            //检查当前日期目录是否存在，不存在则创建
            if (!System.IO.Directory.Exists(dirname))
                System.IO.Directory.CreateDirectory(dirname);
            //获取当前时间戳
            string timestamp = ConvertDateTimeInt(DateTime.Now).ToString();
            //生成存档文件名
            string receiveinfoxmlfilename = dirname + @"\receiveinfo-" + timestamp + @".xml";
            string loaninfoxmlfilename = dirname + @"\loaninfo-" + timestamp + @".xml";
            //保存票据XML文件
            if (!System.IO.File.Exists(receiveinfoxmlfilename))
            {
                FileStream fs = new FileStream(receiveinfoxmlfilename, FileMode.CreateNew, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(receiveinfoxml);
                sw.Close();
                fs.Close();
            }
            //保存代收信息XML文件
            if (!System.IO.File.Exists(loaninfoxmlfilename))
            {
                FileStream fs = new FileStream(loaninfoxmlfilename, FileMode.CreateNew, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(loaninfoxml);
                sw.Close();
                fs.Close();
            }
        }

        /// <summary>   
        /// DES加密字符串   
        /// </summary>   
        /// <param name="encryptString">待加密的字符串</param>   
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <param name="encryptIV">加密向量,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>   
        private static String EncryptDES(String encryptString, String encryptKey, String encryptIV)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(encryptIV.Substring(0, 8));
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                dCSP.Mode = CipherMode.CBC;
                dCSP.Padding = PaddingMode.ISO10126;
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);

                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>   
        /// DES解密字符串   
        /// </summary>   
        /// <param name="decryptString">待解密的字符串</param>   
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <param name="decryptIV">解密向量,要求为8位,和加密向量相同</param>   
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>   
        private static String DecryptDES(String decryptString, String decryptKey, String decryptIV)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(decryptIV.Substring(0, 8));
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                dCSP.Mode = CipherMode.CBC;
                dCSP.Padding = PaddingMode.ISO10126;
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        /// <summary>
        /// 向大红门集团接口提交数据XML文件
        /// </summary>
        /// <param name="receiveinfoxml">票据信息XML文件，生成单据，修改单据状态，修改单据内容是应非空</param>
        /// <param name="loaninfoxml">代收放款信息XML文件，发放代收时应为非空</param>
        public static void UploadXml(string receiveinfoxml, string loaninfoxml)
        {
            //物流公司代码
            const string comcode = "1112";

            //将提交的Xml文件保存
            FileSaveBackup(receiveinfoxml, loaninfoxml);
            //创建服务对象
            TransitService ts = new TransitService();
            //用“物流公司编码”获取加密密钥
            string key = ts.GetDESKey(comcode);
            //用“yyyyMMdd”格式获取当前日期作为加密种子
            string iv = DateTime.Now.ToString("yyyyMMdd");
            //对密钥进行处理
            byte[] outputb = Convert.FromBase64String(key);//解密Base64
            key = Encoding.UTF8.GetString(outputb);
            //上传XML文件，单传票据时，loaninfoxml可为空值xml文件，传代收时，应均有数据。放代收时，receiveinfoxml应含有修改状态的票据信息
            string xml1 = EncryptDES(receiveinfoxml, key, iv);
            string xml2 = EncryptDES(loaninfoxml, key, iv);
        UploadXml:
            try
            {
                //发布解除上传数据
                //ts.SetInfo(xml1, xml2, comcode);
            }
            catch
            {
                //上传出错，持续提交
                goto UploadXml;
            }
        }
    }
}