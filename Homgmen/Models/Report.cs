namespace Homgmen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 提交报表数据库
    /// </summary>
    [Table("Report")]
    public partial class Report
    {
        /// <summary>
        /// 报表日期
        /// </summary>
        [Required]
        [Key]
        public DateTime DateID { get; set; }

        /// <summary>
        /// 当日提交发货单据数
        /// </summary>
        [Required]
        public int SendNumber { get; set; }

        /// <summary>
        /// 提交的代收货款金额
        /// </summary>
        [Required]
        public decimal Monery { get; set; }

        /// <summary>
        /// 当日到货的单据数据
        /// </summary>
        [Required]
        public int ArrivalsNumber { get; set; }

        /// <summary>
        /// 当日放款单据票数
        /// </summary>
        [Required]
        public int PaymentNumber { get; set; }

        /// <summary>
        /// 当日放款金额
        /// </summary>
        public decimal PaymentMonery { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Note { get; set; }
    }
}