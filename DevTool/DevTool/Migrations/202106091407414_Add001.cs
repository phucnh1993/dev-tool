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
                "dbo.DataTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActivated = c.Boolean(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100, unicode: false),
                        Name = c.String(nullable: false, maxLength: 250, unicode: false),
                        MaxLength = c.Int(nullable: false),
                        MultiName = c.String(nullable: false, unicode: false),
                        MultiNameMapType = c.String(nullable: false, unicode: false),
                        Description = c.String(maxLength: 2000, storeType: "nvarchar"),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.IsActivated, t.Code }, name: "IX_DataTypeSearch");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "GroupParent_Id", "dbo.Categories");
            DropIndex("dbo.DataTypes", "IX_DataTypeSearch");
            DropIndex("dbo.Categories", new[] { "GroupParent_Id" });
            DropIndex("dbo.Categories", new[] { "GroupId" });
            DropIndex("dbo.Categories", "IX_CategorySearch");
            DropTable("dbo.DataTypes");
            DropTable("dbo.Categories");
        }
    }
}
