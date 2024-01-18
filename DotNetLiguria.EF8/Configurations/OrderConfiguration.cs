using DotNetLiguria.EF8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetLiguria.EF8.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("OrderId");

        builder.ComplexProperty(builder => builder.ShippingAddress).IsRequired();
        builder.ComplexProperty(builder => builder.BillingAddress).IsRequired();

        builder.HasOne(c => c.Customer).WithMany(c => c.Orders).HasForeignKey(c => c.CustomerId);
    }
}
