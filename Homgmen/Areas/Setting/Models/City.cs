namespace Homgmen.Areas.Setting.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class City : DbContext
    {
        public City()
            : base("name=City")
        {
        }

        public virtual DbSet<Citytel> Citytels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citytel>()
                .Property(e => e.城市)
                .IsFixedLength();

            modelBuilder.Entity<Citytel>()
                .Property(e => e.编号)
                .IsFixedLength();

            modelBuilder.Entity<Citytel>()
                .Property(e => e.电话)
                .IsFixedLength();

            modelBuilder.Entity<Citytel>()
                .Property(e => e.完成度)
                .IsFixedLength();
        }
    }
}
