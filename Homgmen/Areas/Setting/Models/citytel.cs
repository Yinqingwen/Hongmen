namespace Homgmen.Areas.Setting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 站点基本数据信息类
    /// </summary>
    [Table("citytel")]
    public partial class Citytel
    {
        /// <summary>
        /// 站点ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 站点城市
        /// </summary>
        [StringLength(6)]
        public string 城市 { get; set; }

        /// <summary>
        /// 站点编号
        /// </summary>
        [StringLength(10)]
        public string 编号 { get; set; }

        /// <summary>
        /// 站点电话
        /// </summary>
        [StringLength(13)]
        public string 电话 { get; set; }

        /// <summary>
        /// 站点保证金
        /// </summary>
        public long? 保证金 { get; set; }

        /// <summary>
        /// 站点是否可用标志
        /// </summary>
        [StringLength(1)]
        public string 完成度 { get; set; }
    }
}
