using System.ComponentModel.DataAnnotations;

namespace DotNetLiguria.EF8.Models;

public class Order
{
    public int Id { get; set; }
    public required int CustomerId { get; set; }

    [Required]
    public required string Contents { get; set; }

    public required Address ShippingAddress { get; set; }
    
    public required Address BillingAddress { get; set; }

    public virtual Customer Customer { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    public TimeOnly? PreferredDeliveryTime { get; set; }
}
