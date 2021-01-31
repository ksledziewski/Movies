namespace Movies.Interfaces
{
    /// <summary>
    /// Movie repository
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>
        /// Add new rating
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <param name="score">Score</param>
        void AddNewRating(string title, int score);

        /// <summary>
        /// Get average move rating
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <returns>Movie</returns>
        double GetMovieAverageRatings(string title);
    }
}