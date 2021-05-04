using System;
using System.Collections.Generic;

namespace RecordLabel.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
