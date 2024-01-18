using DotNetLiguria.EF8.Models;

namespace DotNetLiguria.EF8.WebApi.RequestModels
{
    public class OrderRequest
    {
        public required string Contents { get; set; }
        public required Address ShippingAddress { get; set; }
        public required Address BillingAddress { get; set; }
    }
}
