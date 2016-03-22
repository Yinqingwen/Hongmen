namespace Homgmen.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OldSot : DbContext
    {
        public OldSot()
            : base("name=Olddb")
        {
        }

        public virtual DbSet<Sot> Sots { get; set; }
    }
}