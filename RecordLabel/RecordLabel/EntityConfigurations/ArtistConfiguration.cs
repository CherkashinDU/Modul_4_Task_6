using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecordLabel.Entities;

namespace RecordLabel.EntityConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(c => c.Id);
            builder.Property(a => a.Id).HasColumnName("ArtistId");
            builder.Property(a => a.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
            builder.Property(a => a.DateOfBirth).IsRequired().HasColumnName("DateOfBirth").HasColumnType("date");
            builder.Property(a => a.Phone).HasColumnName("Phone").HasMaxLength(30);
            builder.Property(a => a.Email).HasColumnName("Email").HasMaxLength(100);
            builder.Property(a => a.InstagramUrl).HasColumnName("InstagramUrl").HasMaxLength(255);

            builder.HasMany(a => a.Songs)
                .WithMany(s => s.Artists)
                .UsingEntity<Dictionary<string, object>>(
                "ArtistSong",
                a => a
                .HasOne<Song>()
                .WithMany()
                .HasForeignKey("SongId").OnDelete(DeleteBehavior.Restrict),
                s => s
                .HasOne<Artist>()
                .WithMany()
                .HasForeignKey("ArtistId").OnDelete(DeleteBehavior.Restrict));
        }
    }
}
