using Microsoft.EntityFrameworkCore.Migrations;

namespace RecordLabel.Migrations
{
    public partial class FillAllBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                    "INSERT INTO " +
                    "Genre (Title) " +
                    "VALUES " +
                    "('Synthpop'), " +
                    "('Electronic'), " +
                    "('Drum and bass'), " +
                    "('Dance'), " +
                    "('Pop')");

            migrationBuilder.Sql(
                "INSERT INTO " +
                "Artist (Name, DateOfBirth, Phone, Email, InstagramUrl) " +
                "VALUES " +
                "('Hurts', '2009-05-21', 'NULL', 'NULL', 'https://www.instagram.com/theohurts/'), " +
                "('Apashe', '1992-05-09', 'NULL', NULL, 'https://www.instagram.com/apashe/'), " +
                "('RAYE', '1997-10-24', 'NULL', 'NULL', 'https://www.instagram.com/raye/'), " +
                "('Rudimental', '2011-03-01','NULL', 'NULL', 'NULL'), " +
                "('INNA', '1986-10-16', 'NULL', 'NULL', 'https://www.instagram.com/inna/')");

            migrationBuilder.Sql(
                "INSERT INTO " +
                "Song (Title, Duration, ReleasedDate, GenreId) " +
                "VALUES " +
                "('Redemption', '00:04:20', '2020-07-16', (SELECT GenreId FROM Genre WHERE Title = 'Synthpop')), " +
                "('Distance feat. Geoffroy', '00:03:39', '2019-12-05', (SELECT GenreId FROM Genre WHERE Title = 'Electronic')), " +
                "('Legend ft. Wasiu', '00:03:40', '2020-04-15', (SELECT GenreId FROM Genre WHERE Title = 'Electronic')), " +
                "('Regardless', '00:03:18', '2021-01-08', (SELECT GenreId FROM Genre WHERE Title = 'Dance')), " +
                "('Waiting All Night ft. Ella Eyre', '00:05:15', '2013-04-04', (SELECT GenreId FROM Genre WHERE Title = 'Drum and bass')), " +
                "('Flashbacks', '00:03:01', '1963-02-26', (SELECT GenreId FROM Genre WHERE Title = 'Dance'))");

            migrationBuilder.Sql(
                "INSERT INTO " +
                "ArtistSong (ArtistId, SongId) " +
                "VALUES " +
                "((SELECT ArtistId FROM Artist WHERE Name = 'Hurts'), (SELECT SongId FROM Song WHERE Title = 'Redemption')), " +
                "((SELECT ArtistId FROM Artist WHERE Name = 'Apashe'), (SELECT SongId FROM Song WHERE Title = 'Distance feat. Geoffroy')), " +
                "((SELECT ArtistId FROM Artist WHERE Name = 'Apashe'), (SELECT SongId FROM Song WHERE Title = 'Legend ft. Wasiu')), " +
                "((SELECT ArtistId FROM Artist WHERE Name = 'RAYE'), (SELECT SongId FROM Song WHERE Title = 'Regardless')), " +
                "((SELECT ArtistId FROM Artist WHERE Name = 'Rudimental'), (SELECT SongId FROM Song WHERE Title = 'Regardless')), " +
                "((SELECT ArtistId FROM Artist WHERE Name = 'INNA'), (SELECT SongId FROM Song WHERE Title = 'Flashbacks')), " +
                "((SELECT ArtistId FROM Artist WHERE Name = 'Rudimental'), (SELECT SongId FROM Song WHERE Title = 'Waiting All Night ft. Ella Eyre'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
              "DELETE FROM ArtistSong");

            migrationBuilder.Sql(
               "DELETE FROM Song");

            migrationBuilder.Sql("DBCC CHECKIDENT(Song, RESEED, 0)");

            migrationBuilder.Sql(
               "DELETE FROM Artist");

            migrationBuilder.Sql("DBCC CHECKIDENT(Artist, RESEED, 0)");

            migrationBuilder.Sql(
                   "DELETE FROM Genre");

            migrationBuilder.Sql("DBCC CHECKIDENT(Genre, RESEED, 0)");
        }
    }
}
