using Microsoft.EntityFrameworkCore;

namespace Movies.Persistence
{
    /// <summary>
    /// Movie scoring db context
    /// </summary>
    internal class MovieRatingDbContext : DbContext
    {
        /// <summary>
        /// Movie score db set
        /// </summary>
        public DbSet<MovieRatingDO> MovieScores { get; set; }

        /// <summary>
        /// Context configuration
        /// NOTE: Connection string would be in the application config file in the real world solution
        /// </summary>
        /// <param name="options">Options builder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=MovieScoring.db");

        /// <summary>
        /// Handling for model creation
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieRatingDO>(builder =>
            {
                builder.HasKey(key => key.Id);
                builder.ToTable("MovieRatings");
            });
        }
    }
}