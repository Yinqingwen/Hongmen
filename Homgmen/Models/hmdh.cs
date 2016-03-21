namespace Homgmen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hmdh")]
    public partial class hmdh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public int? 垫付款 { get; set; }

        public int? 运费 { get; set; }

        public long? 代收款 { get; set; }

        public DateTime? 时间 { get; set; }

        public DateTime? 日期 { get; set; }

        [StringLength(10)]
        public string 完成度 { get; set; }

        public bool? 上传状态 { get; set; }
    }
}
