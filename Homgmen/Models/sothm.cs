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
        public sothm(Sot sot)
        {
            ID = sot.ID;
            if (sot.收货人 != null || sot.收货人 != string.Empty)
                this.收货人 = sot.收货人;
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
