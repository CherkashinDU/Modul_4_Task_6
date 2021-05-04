using System;
using System.Collections.Generic;

namespace RecordLabel.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string InstagramUrl { get; set; }
        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}
