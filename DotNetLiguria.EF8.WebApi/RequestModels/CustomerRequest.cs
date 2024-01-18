using DotNetLiguria.EF8.Models;
using System.ComponentModel.DataAnnotations;

namespace DotNetLiguria.EF8.WebApi.RequestModels
{
    public class CustomerRequest
    {
        public required string Name { get; set; }
        public required Address Address { get; set; }
    }
}
