namespace ScanWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataSources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HiltNum = c.String(unicode: false),
                        HiltSpecification = c.String(unicode: false),
                        ToolSpecification = c.String(unicode: false),
                        ToolId = c.String(unicode: false),
                        ToolName = c.String(unicode: false),
                        ToolLength = c.String(unicode: false),
                        ToolCurrLife = c.String(unicode: false),
                        ToolMaxLife = c.String(unicode: false),
                        ToolTheoryR = c.String(unicode: false),
                        ToolRealR = c.String(unicode: false),
                        ToolJump = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ScanResultTables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ScanResult = c.String(unicode: false),
                        Type = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScanResultTables");
            DropTable("dbo.DataSources");
        }
    }
}
