using System;
using System.Collections.Generic;
using System.Linq;
using Movies.Interfaces;
using Movies.Models;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Movies.ExternalServices
{
    /// <summary>
    /// Handler for external movie API calls
    /// </summary>
    public class MovieExternalServiceAdapter: IMovieExternalService
    {
        // NOTE: This should be in the application config
        private const string ApiUri = "https://swapi.dev";
        
        /// <summary>
        /// Get all moves from external API
        /// </summary>
        /// <returns>List of movies</returns>
        public IEnumerable<Movie> GetAllMovies() => 
            RetrieveAllMovies();

        /// <summary>
        /// Get movie
        /// </summary>
        /// <param name="title">Movie's title</param>
        /// <returns>Movie</returns>
        public Movie GetMovie(string title) =>
            RetrieveMovie(title);

        // Movies' retrieval method
        private IEnumerable<Movie> RetrieveAllMovies()
        {
            var restClient = new RestClient(ApiUri);
            restClient.UseNewtonsoftJson();
            
            var request = new RestRequest("api/films/", DataFormat.Json);

            try
            {
                var response = restClient.Get<MovieListContainer>(request);
                if (response.IsSuccessful)
                    return response
                        .Data
                        .Results;

                return Enumerable.Empty<Movie>();
            }
            catch (Exception e)
            {
                // NOTE: Log error
                // Furthermore, exception could be rethrown here, but I decided not to for code simplicity
            }

            return Enumerable.Empty<Movie>();
        }
        
        
        // Movie retrieval method
        private Movie RetrieveMovie(string title)
        {
            var restClient = new RestClient(ApiUri);
            restClient.UseNewtonsoftJson();
            
            var request = new RestRequest($"api/films/", DataFormat.Json);
            request.AddQueryParameter("search", title);
            
            try
            {
                var response = restClient.Get<MovieListContainer>(request);
                
                if(response.IsSuccessful)
                    return response.Data?.Results.First() ?? null;

                return null;
            }
            catch (Exception e)
            {
                // NOTE: Log error
                // Furthermore, exception could be rethrown here, but I decided not to for code simplicity
            }

            return null;
        }
    }
}