using System;
using System.Collections.Generic;

#nullable disable

namespace CineTecBackend
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
            Screenings = new HashSet<Screening>();
        }

        public string OriginalName { get; set; }
        public string Gendre { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string ImageUrl { get; set; }
        public int? Lenght { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
