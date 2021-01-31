using System.Collections.Generic;
using Movies.Helpers;
using Movies.Interfaces;
using Movies.Models;

namespace Movies.Logic
{
    /// <summary>
    /// Movie logic
    /// </summary>
    public class MovieLogic
    {
        // NOTE: Inversed dependency to be able to unit test logic
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieExternalService _movieExternalService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="movieRepository">Movie repository</param>
        /// <param name="movieExternalService">Movie external service</param>
        public MovieLogic(IMovieRepository movieRepository, IMovieExternalService movieExternalService)
        {
            _movieRepository = movieRepository;
            _movieExternalService = movieExternalService;
        }
        
        /// <summary>
        /// Add new movie rating
        /// </summary>
        /// <param name="title">Movie's title</param>
        /// <param name="score">Movie's score</param>
        /// <returns>Adding score result</returns>
        public ValidationResult RateMovie(string title, int score)
        {
            if (string.IsNullOrEmpty(title))
                return new ValidationResult(false, "Movie's title cannot be empty");
            if (score <= 0)
                return new ValidationResult(false, "Score cannot be lower than 1");
            if (score > 10)
                return new ValidationResult(false, "Score cannot be greater than 10");

            // Note: Caching could be introduced here, not to call external service every time
            var movie = _movieExternalService.GetMovie(title);
            if (movie == null)
                return new ValidationResult(false, $"Movie {title} does not exist");
            
            
            _movieRepository.AddNewRating(title, score);

            return new ValidationResult(true);
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetAllMovies() =>
            _movieExternalService.GetAllMovies();

        /// <summary>
        /// Get movie
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <returns>Movie</returns>
        public Movie GetMovie(string title)
        {
            if (string.IsNullOrEmpty(title))
                return null;
            
            // Note: Caching could be introduced here, not to call external service every time
            var movie = _movieExternalService.GetMovie(title);
            if (movie == null)
                return null;

            movie.Rating = _movieRepository.GetMovieAverageRatings(title);
            return movie;
        }
            

    }
}