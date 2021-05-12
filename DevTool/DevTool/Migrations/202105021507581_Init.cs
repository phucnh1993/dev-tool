namespace DevTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "cmd.AppRun",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AppName = c.String(nullable: false, maxLength: 100, unicode: false),
                        AppType = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "cmd.CommandRun",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CommandContent = c.String(nullable: false, maxLength: 1024, unicode: false),
                        CommandDecription = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "cmd.AppCommandRuns",
                c => new
                    {
                        AppId = c.Long(nullable: false),
                        CommandId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppId, t.CommandId })
                .ForeignKey("cmd.AppRun", t => t.AppId, cascadeDelete: true)
                .ForeignKey("cmd.CommandRun", t => t.CommandId, cascadeDelete: true)
                .Index(t => t.AppId)
                .Index(t => t.CommandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("cmd.AppCommandRuns", "CommandId", "cmd.CommandRun");
            DropForeignKey("cmd.AppCommandRuns", "AppId", "cmd.AppRun");
            DropIndex("cmd.AppCommandRuns", new[] { "CommandId" });
            DropIndex("cmd.AppCommandRuns", new[] { "AppId" });
            DropTable("cmd.AppCommandRuns");
            DropTable("cmd.CommandRun");
            DropTable("cmd.AppRun");
        }
    }
}
