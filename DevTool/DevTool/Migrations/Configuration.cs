namespace DevTool.Migrations
{
    using DevTool.Domains;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CreatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(CreatorContext context)
        {
        }
    }
}
