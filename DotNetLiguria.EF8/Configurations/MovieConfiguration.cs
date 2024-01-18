using DotNetLiguria.EF8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetLiguria.EF8.Configurations;

internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("MovieId");
        builder.Property(c => c.Title).IsRequired();

        builder.Property(c => c.Genres).HasMaxLength(512).IsUnicode(false).IsRequired();
    }
}
