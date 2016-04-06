namespace Homgmen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Idde")]
    public partial class Idde
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string 设备号 { get; set; }

        [StringLength(10)]
        public string 业务员 { get; set; }

        [StringLength(10)]
        public string 收货网点 { get; set; }

        [StringLength(10)]
        public string 始发城市 { get; set; }

        [StringLength(10)]
        public string 责任人 { get; set; }

        [StringLength(10)]
        public string 完成度 { get; set; }
    }
}
