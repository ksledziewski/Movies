using System.Collections.Generic;
using System.Linq;
using Movies.Interfaces;
using Movies.Models;

namespace Movies.Test.Adapters
{
    /// <summary>
    /// External service adapter for tests
    /// </summary>
    public class MovieExternalServiceAdapter: IMovieExternalService
    {
        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns>Movie list</returns>
        public IEnumerable<Movie> GetAllMovies() =>
            Enumerable.Empty<Movie>();

        /// <summary>
        /// Get movie by id
        /// </summary>
        /// <param name="title">Movie's title</param>
        /// <returns>Movie</returns>
        public Movie GetMovie(string title) => 
            (title == "Test") ? 
                new Movie() {Title = "Test"} : 
                null;
    }
}