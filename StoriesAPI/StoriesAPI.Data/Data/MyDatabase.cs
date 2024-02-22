using Microsoft.EntityFrameworkCore;
using StoriesAPI.Infrastructure.Models;

namespace StoriesAPI.Infrastructure.Data
{
    public class MyDatabase : DbContext
    {
        public const string DEFAULT_SCHEMA = "story_schema";

        public MyDatabase(DbContextOptions<MyDatabase> options)
            : base(options)
        {
        }

        public DbSet<Story> Stories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Story)
                .WithMany(s => s.Votes)
                .HasForeignKey(v => v.StoryId);
        
            base.OnModelCreating(modelBuilder);

        }
    }
}
