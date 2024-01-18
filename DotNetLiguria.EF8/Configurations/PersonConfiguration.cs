using DotNetLiguria.EF8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetLiguria.EF8.Configurations;

internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("PersonId");
        builder.Property(c => c.Name).IsRequired();
    }
}
