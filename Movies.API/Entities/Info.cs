using Newtonsoft.Json;

namespace Movies.API.Entities
{
    public class Info
    {
        public IEnumerable<string> Directors { get; set; }
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
        public IEnumerable<string> Genres { get; set; }
        [JsonProperty("image_url")]
        public string? ImageUrl { get; set; }
        public string? Plot { get; set; }
        public int Rank { get; set; }
        [JsonProperty("running_time_secs")]
        public int RunningTimeSecs { get; set; }
        public IEnumerable<string> Actors { get; set; }
    }
}
