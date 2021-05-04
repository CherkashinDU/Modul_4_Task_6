using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecordLabel.Entities;

namespace RecordLabel.EntityConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(c => c.Id);
            builder.Property(s => s.Id).HasColumnName("SongId");
            builder.Property(s => s.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
            builder.Property(s => s.Duration).IsRequired().HasColumnName("Duration").HasColumnType("time");
            builder.Property(s => s.ReleasedDate).IsRequired().HasColumnName("ReleasedDate").HasColumnType("date");

            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
