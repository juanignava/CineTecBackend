using System;
using System.Collections.Generic;

#nullable disable

namespace CineTecBackend
{
    public partial class Seat
    {
        public int CinemaNumber { get; set; }
        public int RowNum { get; set; }
        public int ColumnNum { get; set; }
        public string State { get; set; }

        public virtual Cinema CinemaNumberNavigation { get; set; }
    }
}
