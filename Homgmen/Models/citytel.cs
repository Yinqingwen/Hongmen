namespace Homgmen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("citytel")]
    public partial class citytel
    {
        public long ID { get; set; }

        [StringLength(6)]
        public string 城市 { get; set; }

        [StringLength(10)]
        public string 编号 { get; set; }

        [StringLength(13)]
        public string 电话 { get; set; }

        public long? 保证金 { get; set; }

        [StringLength(1)]
        public string 完成度 { get; set; }
    }
}
