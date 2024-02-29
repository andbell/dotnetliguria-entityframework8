using System.ComponentModel.DataAnnotations;

namespace DotNetLiguria.EF8.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public required Address Address { get; set; }

    public virtual ICollection<Order>? Orders { get; set; }
}
