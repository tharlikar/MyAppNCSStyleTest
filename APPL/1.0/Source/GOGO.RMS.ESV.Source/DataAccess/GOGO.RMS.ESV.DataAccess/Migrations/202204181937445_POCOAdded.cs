namespace GOGO.RMS.ESV.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POCOAdded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.Products", "LastUpdated", c => c.DateTime());
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "SKU", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "CreatedBy", c => c.String());
            AlterColumn("dbo.Products", "LastUpdatedBy", c => c.String());
            AddPrimaryKey("dbo.Products", "Id");
            DropColumn("dbo.Products", "LastUpdate");
            DropColumn("dbo.Products", "DatabaseLoginId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DatabaseLoginId", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "LastUpdate", c => c.DateTime());
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "LastUpdatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "SKU", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false, identity: true));
            DropColumn("dbo.Products", "LastUpdated");
            AddPrimaryKey("dbo.Products", "Id");
        }
    }
}
