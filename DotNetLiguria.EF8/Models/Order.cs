namespace DotNetLiguria.EF8.Models;

public class Order
{
    public required int Id { get; set; }
    public required int CustomerId { get; set; }
    public required string Contents { get; set; }
    public Address ShippingAddress { get; set; }
    public Address BillingAddress { get; set; }

    public virtual Customer Customer { get; set; }
}
