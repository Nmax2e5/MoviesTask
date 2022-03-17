using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Info
    {
        public IEnumerable<string> Directors { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string ImageUrl { get; set; }
        public string Plot { get; set; }
        public int Rank { get; set; }
        public int RunningTimeSecs { get; set; }
        public IEnumerable<string> Actors { get; set; } 
    }
}
