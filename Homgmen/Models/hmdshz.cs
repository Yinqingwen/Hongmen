namespace Homgmen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hmdshz")]
    public partial class hmdshz
    {
        public long id { get; set; }

        [Required]
        [StringLength(10)]
        public string 结算单号 { get; set; }

        public DateTime 放款时间 { get; set; }

        [Required]
        [StringLength(20)]
        public string 银行卡号 { get; set; }

        [Column(TypeName = "money")]
        public decimal 实收货款 { get; set; }

        [Column(TypeName = "money")]
        public decimal 放款手续费 { get; set; }

        [Column(TypeName = "money")]
        public decimal 始发代收货款 { get; set; }

        public int 放款票据份数 { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string 收货编号集合 { get; set; }

        [StringLength(10)]
        public string 物流公司编号 { get; set; }

        [StringLength(10)]
        public string 放款站点编号 { get; set; }

        [Required]
        [StringLength(10)]
        public string 放款银行编号 { get; set; }

        [Required]
        [StringLength(10)]
        public string 持卡人姓名 { get; set; }

        public bool 上传状态 { get; set; }
    }
}
