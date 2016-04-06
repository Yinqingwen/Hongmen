namespace Homgmen.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Site : DbContext
    {
        public Site()
            : base("name=Site")
        {
        }

        public virtual DbSet<citytel> citytel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<citytel>()
                .Property(e => e.城市)
                .IsFixedLength();

            modelBuilder.Entity<citytel>()
                .Property(e => e.编号)
                .IsFixedLength();

            modelBuilder.Entity<citytel>()
                .Property(e => e.电话)
                .IsFixedLength();

            modelBuilder.Entity<citytel>()
                .Property(e => e.完成度)
                .IsFixedLength();
        }
    }
}
