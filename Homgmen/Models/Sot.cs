namespace Homgmen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sot")]
    public partial class sot
    {
        public long ID { get; set; }

        [StringLength(10)]
        public string 会员号 { get; set; }

        [StringLength(10)]
        public string 流水号 { get; set; }

        [StringLength(10)]
        public string 收货网点 { get; set; }

        [StringLength(10)]
        public string 始发城市 { get; set; }

        [StringLength(6)]
        public string 目的城市 { get; set; }

        [StringLength(5)]
        public string 下线名 { get; set; }

        [StringLength(15)]
        public string 货物名称 { get; set; }

        [StringLength(10)]
        public string 件数 { get; set; }

        [StringLength(10)]
        public string 收货人 { get; set; }

        [StringLength(12)]
        public string 收货人电话 { get; set; }

        [StringLength(12)]
        public string 发货人电话 { get; set; }

        [StringLength(10)]
        public string 垫付款 { get; set; }

        [StringLength(10)]
        public string 代收金额 { get; set; }

        [StringLength(10)]
        public string 保价金额 { get; set; }

        [StringLength(10)]
        public string 手续费 { get; set; }

        [StringLength(10)]
        public string 保价费 { get; set; }

        [StringLength(10)]
        public string 提货费 { get; set; }

        [StringLength(10)]
        public string 送货费 { get; set; }

        [StringLength(10)]
        public string 工本费 { get; set; }

        [StringLength(10)]
        public string 包装费 { get; set; }

        [StringLength(10)]
        public string 运费 { get; set; }

        [StringLength(10)]
        public string 现返 { get; set; }

        [StringLength(10)]
        public string 欠返 { get; set; }

        [StringLength(10)]
        public string 伙伴中转 { get; set; }

        [StringLength(10)]
        public string 赔付减免 { get; set; }

        [StringLength(10)]
        public string 下线中转 { get; set; }

        [StringLength(10)]
        public string 重量 { get; set; }

        [StringLength(10)]
        public string 体积 { get; set; }

        [StringLength(10)]
        public string 是否回单 { get; set; }

        [StringLength(10)]
        public string 付款方式 { get; set; }

        [StringLength(10)]
        public string 中转方式 { get; set; }

        [StringLength(10)]
        public string 设备号 { get; set; }

        [StringLength(10)]
        public string 业务员 { get; set; }

        [StringLength(10)]
        public string 发货人 { get; set; }

        [StringLength(10)]
        public string 备注 { get; set; }

        [StringLength(10)]
        public string 时间 { get; set; }

        [StringLength(15)]
        public string 托运日期 { get; set; }

        [StringLength(13)]
        public string 城市电话 { get; set; }

        [StringLength(10)]
        public string 状态 { get; set; }

        [StringLength(10)]
        public string 完成度 { get; set; }
    }
}
