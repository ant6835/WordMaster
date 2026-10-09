using Microsoft.EntityFrameworkCore;

namespace WordMaster.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<string> Words { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<string>().HasData(
                "count",
                "flush",
                "eerie",
                "fault",
                "blast",
                "trick",
                "scare",
                "folly",
                "steam",
                "quark",
                "field",
                "house",
                "cloth",
                "realm",
                "weird",
                "noise",
                "crumb",
                "clank",
                "night"
            );
        }
    }
}
