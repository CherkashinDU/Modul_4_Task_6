using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecordLabel.Entities;

namespace RecordLabel.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(c => c.Id);
            builder.Property(g => g.Id).HasColumnName("GenreId");
            builder.Property(g => g.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
        }
    }
}