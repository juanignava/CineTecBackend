using System;
using System.Collections.Generic;

#nullable disable

namespace CineTecBackend
{
    public partial class Screening
    {
        public int CinemaNumber { get; set; }
        public string MovieOriginalName { get; set; }
        public int Hour { get; set; }

        public virtual Cinema CinemaNumberNavigation { get; set; }
        public virtual Movie MovieOriginalNameNavigation { get; set; }
    }
}
