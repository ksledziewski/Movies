using Movies.Interfaces;

namespace Movies.Test.Adapters
{
    /// <summary>
    /// Fake movie repository for tests
    /// </summary>
    public class MovieRepositoryAdapter: IMovieRepository
    {
        /// <summary>
        /// Mock add new rating db action
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <param name="score">Movie rating</param>
        public void AddNewRating(string title, int score)
        {
            // Do nothing, just mock
        }

        /// <summary>
        /// Mock movie average rating retrieval 
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <returns>Rating</returns>
        public double GetMovieAverageRatings(string title)
        {
            return 0;
        }
    }
}