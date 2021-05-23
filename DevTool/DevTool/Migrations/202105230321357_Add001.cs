namespace DevTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        Sort = c.Int(nullable: false),
                        IsActivated = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 2000, storeType: "nvarchar"),
                        CategoryData = c.Binary(),
                        GroupId = c.Long(),
                        GroupParent_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.GroupParent_Id)
                .Index(t => new { t.IsActivated, t.GroupId, t.Name }, name: "IX_CategorySearch")
                .Index(t => t.GroupId)
                .Index(t => t.GroupParent_Id);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CodeSupport = c.String(nullable: false, maxLength: 100, unicode: false),
                        Name = c.String(nullable: false, maxLength: 250, unicode: false),
                        HashData = c.String(nullable: false, maxLength: 64, unicode: false),
                        Description = c.String(maxLength: 2000, storeType: "nvarchar"),
                        FunctionData = c.Binary(nullable: false),
                        IsActivated = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.IsActivated, t.CodeSupport, t.Name }, name: "IX_FunctionSearch")
                .Index(t => t.HashData, unique: true, name: "IX_FunctionHashData");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "GroupParent_Id", "dbo.Categories");
            DropIndex("dbo.Functions", "IX_FunctionHashData");
            DropIndex("dbo.Functions", "IX_FunctionSearch");
            DropIndex("dbo.Categories", new[] { "GroupParent_Id" });
            DropIndex("dbo.Categories", new[] { "GroupId" });
            DropIndex("dbo.Categories", "IX_CategorySearch");
            DropTable("dbo.Functions");
            DropTable("dbo.Categories");
        }
    }
}
