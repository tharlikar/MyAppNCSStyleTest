namespace GOGO.RMS.ESV.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustColumnWidth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SKU = c.String(maxLength: 50),
                        Name = c.String(maxLength: 100),
                        Created = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        LastUpdate = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 50),
                        DatabaseLoginId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
