using Microsoft.EntityFrameworkCore;

namespace WordMaster.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<Word> Words { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string[] words =
            {
                "count", "flush", "eerie", "fault", "blast",
                "trick", "scare", "folly", "steam", "quark",
                "field", "house", "cloth", "realm", "weird",
                "noise", "crumb", "clank", "night"
            };

            modelBuilder.Entity<Word>().HasData(
                words.Select((word, index) => new Word
                {
                    WordId = index + 1,
                    Value = word
                })
            );
        }
    }
}
