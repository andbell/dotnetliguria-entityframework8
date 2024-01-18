using DotNetLiguria.EF8.Models;

namespace DotNetLiguria.EF8.WebApi.ResponseModels
{
    public class OrderResponse
    {
        public int Id { get; set; } 
        public required string Contents { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public Address? ShippingAddress { get; set; }
    }
}
