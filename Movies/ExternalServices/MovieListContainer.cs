using System.Collections.Generic;
using Movies.Models;

namespace Movies.ExternalServices
{
    /// <summary>
    /// Helper container for movie list retrieval
    /// </summary>
    public class MovieListContainer
    {
        /// <summary>
        /// Movie list
        /// </summary>
        public IEnumerable<Movie> Results { get; set; }
    }
}