namespace DotNetLiguria.EF8.Models;

public class Customer
{
    public required int Id { get; set; }
    public required string Name { get; set; }    
    public Address Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}
