using System.Linq;
using Movies.Interfaces;

namespace Movies.Persistence
{
    /// <summary>
    /// Repository adapter
    /// </summary>
    internal class MovieRepositoryAdapter: IMovieRepository
    {
        /// <summary>
        /// Add new movie rating to db
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <param name="score">Score</param>
        public void AddNewRating(string title, int score)
        {
            using var dbContext = new MovieRatingDbContext();
            var movieRating = new MovieRatingDO()
            {
                Title = title,
                Score = score
            };

            dbContext.MovieScores.Add(movieRating);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Get average move rating
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <returns>Movie's average score</returns>
        public double GetMovieAverageRatings(string title)
        {
            using var dbContext = new MovieRatingDbContext();
            return dbContext.MovieScores
                .Where(x => x.Title == title)
                .Select(x => x.Score)
                .ToList()
                .DefaultIfEmpty(0)
                .Average();
        }
    }
}