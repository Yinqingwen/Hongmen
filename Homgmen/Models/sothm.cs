namespace Homgmen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sothm")]
    public partial class sothm
    {
        public sothm()
        {
        }
        
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sot">旧数据库数据类型</param>
        public sothm(Sot sot)
        {
            //运单票号
            ID = sot.ID;
            //收货人
            this.收货人 = String.IsNullOrWhiteSpace(sot.收货人) ? "无" : sot.收货人.Trim();
            /*
            if (sot.收货人 != null || sot.收货人 != string.Empty)
                this.收货人 = sot.收货人.Trim();
            else
                this.收货人 = "";
             */
            //收货人电话
            this.收货人电话 = String.IsNullOrWhiteSpace(sot.收货人电话) ? "无" : sot.收货人电话.Trim();
            /*
            if (sot.收货人电话 != null || sot.收货人电话 != string.Empty)
                this.收货人电话 = sot.收货人电话.Trim();
            else
                this.收货人电话 = "";
             */
            //发货人
            this.发货人 = String.IsNullOrWhiteSpace(sot.发货人) ? "无" : sot.发货人.Trim();
            /*
            if (sot.发货人 != null || sot.发货人 != string.Empty)
                this.发货人 = sot.发货人.Trim();
            else
                this.发货人 = "";
             */
            //发货人电话
            this.发货人电话 = String.IsNullOrWhiteSpace(sot.发货人电话) ? "无" : sot.发货人电话.Trim();
            /*
            if (sot.发货人电话 != null || sot.发货人电话 != string.Empty)
                this.发货人电话 = sot.发货人电话.Trim();
            else
                this.发货人电话 = "";
             */
            //垫付款
            this.垫付款 = String.IsNullOrWhiteSpace(sot.垫付款) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(sot.垫付款.Trim());
            /*
            if (sot.垫付款 != null || sot.垫付款 != string.Empty)
                this.垫付款 = Convert.ToDecimal(sot.垫付款);
            else
                this.垫付款 = Convert.ToDecimal(0.00);
             */
            //代收金额
            this.代收金额 = String.IsNullOrWhiteSpace(sot.代收金额) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(sot.代收金额.Trim());
            /*
            if (sot.代收金额 != null || sot.代收金额 != string.Empty)
                this.代收金额 = Convert.ToDecimal(sot.代收金额);
            else
                this.代收金额 = Convert.ToDecimal(0.00);
             */
            //运费
            this.运费 = String.IsNullOrWhiteSpace(sot.运费) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(sot.运费.Trim());
            /*
            if (sot.运费 != null || sot.运费 != string.Empty)
                this.运费 = Convert.ToDecimal(sot.运费);
            else
                this.运费 = Convert.ToDecimal(0.00);
             */
            //手续费
            this.手续费 = String.IsNullOrWhiteSpace(sot.手续费) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(sot.手续费.Trim());
            /*
            if (sot.手续费 != null || sot.手续费 != string.Empty)
                this.手续费 = Convert.ToDecimal(sot.手续费);
            else
                this.手续费 = Convert.ToDecimal(0.00);
             */
            //付款方式
            this.付款方式 = String.IsNullOrWhiteSpace(sot.付款方式) ? "提付" : sot.付款方式.Trim();
            /*
            if (sot.付款方式 != null || sot.付款方式 != string.Empty)
                this.付款方式 = sot.付款方式.Trim();
            else
                this.付款方式 = "";
             */
            //托运日期
            this.托运日期 = String.IsNullOrWhiteSpace(sot.托运日期) ? DateTime.Now.Date : Convert.ToDateTime(sot.托运日期.Trim());
            //时间
            this.时间 = String.IsNullOrWhiteSpace(sot.时间) ? DateTime.Now : Convert.ToDateTime(sot.托运日期.Trim() + " " + sot.时间.Trim());
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(10)]
        public string 收货人 { get; set; }

        [StringLength(12)]
        public string 收货人电话 { get; set; }

        [StringLength(12)]
        public string 发货人电话 { get; set; }

        [Column(TypeName = "money")]
        public decimal? 垫付款 { get; set; }

        [Column(TypeName = "money")]
        public decimal? 代收金额 { get; set; }

        [Column(TypeName = "money")]
        public decimal? 手续费 { get; set; }

        [Column(TypeName = "money")]
        public decimal? 运费 { get; set; }

        [StringLength(10)]
        public string 付款方式 { get; set; }

        public DateTime? 时间 { get; set; }

        [StringLength(10)]
        public string 关联编号 { get; set; }

        public DateTime? 托运日期 { get; set; }

        public int? 单据状态 { get; set; }

        public bool? 上传状态 { get; set; }

        [StringLength(10)]
        public string 发货人 { get; set; }
    }
}
