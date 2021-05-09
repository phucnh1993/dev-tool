namespace Duolingo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CreatedDate, unique: true);
            
            CreateTable(
                "dbo.HistoryDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HistoryId = c.Long(nullable: false),
                        TopicId = c.Long(nullable: false),
                        DataTest = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Histories", t => t.HistoryId, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.HistoryId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        HashCompare = c.String(nullable: false, maxLength: 128, unicode: false),
                        Sort = c.Int(nullable: false),
                        IsActivated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EnglishData = c.String(nullable: false, maxLength: 500, unicode: false),
                        EnglishHashCompare = c.String(nullable: false, maxLength: 64, unicode: false),
                        VietnamData = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        VietnamHashCompare = c.String(nullable: false, maxLength: 64, unicode: false),
                        Sort = c.Int(nullable: false),
                        IsActivated = c.Boolean(nullable: false),
                        TopicId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.EnglishData, unique: true)
                .Index(t => t.EnglishHashCompare, unique: true)
                .Index(t => t.VietnamData, unique: true)
                .Index(t => t.VietnamHashCompare, unique: true)
                .Index(t => t.TopicId, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.HistoryDetails", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.HistoryDetails", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Questions", new[] { "TopicId" });
            DropIndex("dbo.Questions", new[] { "VietnamHashCompare" });
            DropIndex("dbo.Questions", new[] { "VietnamData" });
            DropIndex("dbo.Questions", new[] { "EnglishHashCompare" });
            DropIndex("dbo.Questions", new[] { "EnglishData" });
            DropIndex("dbo.HistoryDetails", new[] { "TopicId" });
            DropIndex("dbo.HistoryDetails", new[] { "HistoryId" });
            DropIndex("dbo.Histories", new[] { "CreatedDate" });
            DropTable("dbo.Questions");
            DropTable("dbo.Topics");
            DropTable("dbo.HistoryDetails");
            DropTable("dbo.Histories");
        }
    }
}
