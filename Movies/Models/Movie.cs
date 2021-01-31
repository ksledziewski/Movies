using System;
using Newtonsoft.Json;

namespace Movies.Models
{
    /// <summary>
    /// Movie model
    /// NOTE: In the enterprise application, the model would be separate for domain and for calls to external APIs.
    /// I will use one model for both of them for the sake of simplicity
    /// </summary>
    public class Movie
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("opening_crawl")]
        public string FirstParagraph { get; set; }
        [JsonProperty("director")]
        public string Director { get; set; }
        [JsonProperty("producer")]
        public string Producer { get; set; }
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        // NOTE: Should be in separate model, as in summary described
        public double Rating { get; set; } = 0;
    }
}