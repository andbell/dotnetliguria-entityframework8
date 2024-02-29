using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetLiguria.EF8.Models;

public class Address
{
    [Required]
    public required string Line1 { get; set; }

    public string? Line2 { get; set; }

    [Required]
    public required string City { get; set; }

    [Required]
    public required string Country { get; set; }

    [Required]
    public required string PostCode { get; set; }
}


// We can replace with a record type for immutable objects

[ComplexType]
public record Address1(string Line1, string? Line2, string City, string Country, string PostCode);

[ComplexType]
public record PhoneNumber(int CountryCode, string Number);

[ComplexType]
public record Contact
{
    public required Address Address { get; init; }
    public required PhoneNumber HomePhone { get; init; }
    public required PhoneNumber WorkPhone { get; init; }
    public required PhoneNumber MobilePhone { get; init; }
}