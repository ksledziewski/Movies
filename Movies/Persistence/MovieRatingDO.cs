namespace Movies.Persistence
{
    /// <summary>
    /// Movie score db object
    /// </summary>
    internal class MovieRatingDO
    {
        /// <summary>
        /// Record id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Movie title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Movie score
        /// </summary>
        public int Score { get; set; }
    }
}