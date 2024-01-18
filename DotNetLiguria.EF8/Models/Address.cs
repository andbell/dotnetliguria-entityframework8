using System.ComponentModel.DataAnnotations;

namespace DotNetLiguria.EF8.Models;

public class Address
{
    [Required]
    public required string Line1 { get; set; }
    public string Line2 { get; set; }
    [Required]
    public required string City { get; set; }
    [Required]
    public required string Country { get; set; }
    [Required]
    public required string PostCode { get; set; }
}


// We can replace with a record type for immutable objects
public record Address1(string line1, string? line2, string city, string country, string postCode);

