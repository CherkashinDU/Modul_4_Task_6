using System;
using System.Linq;
using System.Threading.Tasks;
using RecordLabel.Entities;
using Microsoft.EntityFrameworkCore;

namespace RecordLabel
{
    public class LazyLoading
    {
        private readonly ApplicationContext _context;

        public LazyLoading(ApplicationContext context)
        {
            _context = context;
        }

        public async Task JoinArtistSongGenre()
        {
            var joinArtistSongGenre = await _context.Songs
                .Where(s => s.Artists.Any())
                .Select(s => new
                {
                    Name = s.Title,
                    Artists = s.Artists.Select(a => a.Name),
                    Genre = s.Genre.Title
                }).ToListAsync();

            foreach (var item in joinArtistSongGenre)
            {
                Console.WriteLine($"{string.Join(' ', item.Artists)} - {item.Name} ({item.Genre})");
            }
        }

        public async Task CountSongGenre()
        {
            var genres = await _context.Genres
                .Select(g => new
                {
                    Name = g.Title,
                    SongsCount = g.Songs.Count
                }).ToListAsync();

            foreach (var item in genres)
            {
                Console.WriteLine($"{item.Name} - {item.SongsCount}");
            }
        }

        public async Task FilterByBirth()
        {
            var songs = await _context.Songs
                .Where(s => s.ReleasedDate < s.Artists.Max(a => a.DateOfBirth))
                .ToListAsync();

            foreach (var song in songs)
            {
                Console.WriteLine($"{song.Title} - {song.ReleasedDate}");
            }
        }
    }
}
