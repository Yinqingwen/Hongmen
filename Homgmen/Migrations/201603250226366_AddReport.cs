namespace Homgmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SendNumber = c.Int(nullable: false),
                        Monery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ArrivalsNumber = c.Int(nullable: false),
                        PaymentNumber = c.Int(nullable: false),
                        PaymentMonery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
          
        }
        
        public override void Down()
        {
            DropTable("dbo.sothm");
            DropTable("dbo.Report");
            DropTable("dbo.hmdshz");
            DropTable("dbo.hmdh");
        }
    }
}
