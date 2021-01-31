using System.Collections.Generic;
using Movies.Models;

namespace Movies.Interfaces
{
    /// <summary>
    /// Movie external service port
    /// </summary>
    public interface IMovieExternalService
    {
        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetAllMovies();

        /// <summary>
        /// Get movie by its id
        /// </summary>
        /// <param name="title">Movie's title</param>
        /// <returns>Movie</returns>
        Movie GetMovie(string title);
    }
}