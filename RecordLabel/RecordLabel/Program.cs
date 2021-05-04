using System;
using System.Threading.Tasks;

namespace RecordLabel
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).JoinArtistSongGenre();
            }

            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).CountSongGenre();
            }

            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).FilterByBirth();
            }

            Console.ReadKey();
        }
    }
}
