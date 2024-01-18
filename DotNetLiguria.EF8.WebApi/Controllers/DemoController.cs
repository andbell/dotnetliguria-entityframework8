using DotNetLiguria.EF8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF8.WebApi.Controllers;

/// <summary>
/// Demo controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private readonly EF8Context _context;

    public DemoController(EF8Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Get all customers
    /// </summary>
    /// <returns></returns>
    [HttpGet("customers")]
    [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Customer>>> GetAllCustomers()
    {
        var customers = await _context.Customers
            .Select(x => new { x.Id, x.Name, x.Address })
            .ToListAsync();
        
        return Ok(customers);
    }

    /// <summary>
    /// Get all orders by customerId
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpGet("customers/{customerId:int}/orders")]
    [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Order>>> GetAllOrdersByCustomerId(int customerId)
    {
        var orders = await _context.Orders
            .Where(x => x.CustomerId == customerId)
            .ToListAsync();

        return Ok(orders);
    }
}
