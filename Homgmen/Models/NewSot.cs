namespace Homgmen.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewSot : DbContext
    {
        public NewSot()
            : base("name=Newdb")
        {
        }

        public virtual DbSet<hmdh> hmdhs { get; set; }
        public virtual DbSet<hmdshz> hmdshzs { get; set; }
        public virtual DbSet<sothm> sothms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<hmdh>()
                .Property(e => e.完成度)
                .IsFixedLength();

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.结算单号)
                .IsFixedLength();

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.银行卡号)
                .IsFixedLength();

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.实收货款)
                .HasPrecision(19, 4);

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.放款手续费)
                .HasPrecision(19, 4);

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.始发代收货款)
                .HasPrecision(19, 4);

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.收货编号集合)
                .IsUnicode(false);

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.物流公司编号)
                .IsFixedLength();

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.放款站点编号)
                .IsFixedLength();

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.放款银行编号)
                .IsFixedLength();

            modelBuilder.Entity<hmdshz>()
                .Property(e => e.持卡人姓名)
                .IsFixedLength();

            modelBuilder.Entity<sothm>()
                .Property(e => e.收货人)
                .IsFixedLength();

            modelBuilder.Entity<sothm>()
                .Property(e => e.收货人电话)
                .IsFixedLength();

            modelBuilder.Entity<sothm>()
                .Property(e => e.发货人电话)
                .IsFixedLength();

            modelBuilder.Entity<sothm>()
                .Property(e => e.垫付款)
                .HasPrecision(19, 4);

            modelBuilder.Entity<sothm>()
                .Property(e => e.代收金额)
                .HasPrecision(19, 4);

            modelBuilder.Entity<sothm>()
                .Property(e => e.手续费)
                .HasPrecision(19, 4);

            modelBuilder.Entity<sothm>()
                .Property(e => e.运费)
                .HasPrecision(19, 4);

            modelBuilder.Entity<sothm>()
                .Property(e => e.付款方式)
                .IsFixedLength();

            modelBuilder.Entity<sothm>()
                .Property(e => e.关联编号)
                .IsFixedLength();

            modelBuilder.Entity<sothm>()
                .Property(e => e.发货人)
                .IsFixedLength();
        }
    }
}
