using DevTool.Domains.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DevTool.Domains {
    public class ToolContext : DbContext {
        public DbSet<AppRun> AppRuns { get; set; }
        public DbSet<CommandRun> CommandRuns { get; set; }

        public ToolContext() : base("ToolContext") {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<AppRun>().ToTable("AppRun", "cmd");
            modelBuilder.Entity<AppRun>().Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasColumnOrder(0);
            modelBuilder.Entity<AppRun>().Property(p => p.AppName)
                .HasColumnName("AppName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(1)
                .IsUnicode(false)
                .IsRequired();
            modelBuilder.Entity<AppRun>().Property(p => p.AppType)
                .HasColumnName("AppType")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .IsUnicode(false)
                .IsRequired();
            modelBuilder.Entity<AppRun>()
                .HasMany<CommandRun>(x => x.CommandRuns)
                .WithMany(g => g.AppRuns)
                .Map(xg => {
                    xg.MapLeftKey("AppId");
                    xg.MapRightKey("CommandId");
                    xg.ToTable("AppCommandRuns", "cmd");
                });
            modelBuilder.Entity<CommandRun>().ToTable("CommandRun", "cmd");
            modelBuilder.Entity<CommandRun>().Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasColumnOrder(0);
            modelBuilder.Entity<CommandRun>().Property(p => p.CommandContent)
                .HasColumnName("CommandContent")
                .HasColumnType("varchar")
                .HasMaxLength(1024)
                .HasColumnOrder(1)
                .IsUnicode(true)
                .IsRequired();
            modelBuilder.Entity<CommandRun>().Property(p => p.CommandDecription)
                .HasColumnName("CommandDecription")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasColumnOrder(2)
                .IsUnicode(true)
                .IsRequired();
        }
    }
}
