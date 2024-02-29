using DotNetLiguria.EF8.Models;
using DotNetLiguria.EF8.WebApi.RequestModels;
using DotNetLiguria.EF8.WebApi.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF8.WebApi.Controllers;

/// <summary>
/// Demo controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class DemoController(EF8Context context) : ControllerBase
{
    private readonly EF8Context _context = context;

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
    /// Insert a new customer
    /// </summary>
    /// <returns></returns>
    [HttpPost("customers")]
    [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
    public async Task<ActionResult<Customer>> InsertCustomer([FromBody] CustomerRequest newCustomer)
    {
        var customer = new Customer
        {
            Name = newCustomer.Name,
            Address = newCustomer.Address
        };

        _context.Add(customer);
        await _context.SaveChangesAsync();

        return Ok(customer);
    }


    /// <summary>
    /// Update a customer
    /// </summary>
    /// <returns></returns>
    [HttpPut("customers/{customerId:int}")]
    [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
    public async Task<ActionResult<Customer>> UpdateCustomer(int customerId, [FromBody] CustomerRequest customer)
    {
        var actualCustomer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == customerId);

        if (actualCustomer is null)
            return BadRequest("Customer not found");

        actualCustomer.Address = customer.Address;
        actualCustomer.Name = customer.Name;

        await _context.SaveChangesAsync();

        return Ok(actualCustomer);
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

    /// <summary>
    /// Add a new order to the customer
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpPost("customers/{customerId:int}/orders")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
    public async Task<ActionResult<Order>> InsertAnOrder(int customerId, [FromBody] OrderRequest newOrder)
    {
        var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == customerId);

        if (customer is null)
            return BadRequest("Customer not found");

        var order = new Order
        {
            BillingAddress = newOrder.BillingAddress,
            ShippingAddress = newOrder.ShippingAddress,
            Contents = newOrder.Contents,
            CustomerId = customerId,
            OrderDate = DateOnly.FromDateTime(DateTime.Now),
            ShippingTime = new TimeOnly(9, 30, 0, 0, 0)
        };

        _context.Add(order);
        await _context.SaveChangesAsync();

        var orderResponse = new OrderResponse
        {
            Id = order.Id,
            ShippingAddress = order.ShippingAddress,
            Contents = order.Contents,
            CustomerName = customer.Name,
            OrderDate = order.OrderDate 
        };  

        return Ok(orderResponse);
    }

    /// <summary>
    /// Get all movies
    /// </summary>
    /// <returns></returns>
    [HttpGet("movies")]
    [ProducesResponseType(typeof(List<Movie>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<MovieResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Movie>>> GetAllMovies(string? genre = null, bool fromRawSQL = false)
    {
        if (fromRawSQL)
        {
            var rawMovies = _context.Database.SqlQuery<MovieResponse>($"SELECT MovieId, Title, JSON_QUERY(Genres, '$[0]') as FirstGenre FROM Movies");
            return Ok(rawMovies);
        }

        var movies = await _context.Movies
            .Where(x => x.Genres.Contains(genre))
            .ToListAsync();

        return Ok(movies);
    }

    /// <summary>
    /// Insert a new movie
    /// </summary>
    /// <returns></returns>
    [HttpPost("movies")]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
    public async Task<ActionResult<Movie>> InsertMovie([FromBody] MovieRequest newMovie)
    {
        var movie = new Movie(newMovie.Title, newMovie.Genres.ToArray());

        _context.Add(movie);
        await _context.SaveChangesAsync();

        return Ok(movie);
    }

    /// <summary>
    /// Get all people
    /// </summary>
    /// <returns></returns>
    [HttpGet("people")]
    [ProducesResponseType(typeof(List<Person>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Person>>> GetAllPeople()
    {
        var people = await _context.People.ToListAsync();
        return Ok(people);
    }

    /// <summary>
    /// Get all people by Level
    /// </summary>
    /// <returns></returns>
    [HttpGet("people/level/{level}")]
    [ProducesResponseType(typeof(List<Person>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Person>>> GetAllPeopleByLevel(int level)
    {
        var people = await _context.People
            .Where(x => x.Path.GetLevel() == level)
            .ToListAsync();

        return Ok(people);
    }

    /// <summary>
    /// Insert a new person
    /// </summary>
    /// <returns></returns>
    [HttpPost("people")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    public async Task<ActionResult<Person>> InsertPerson([FromBody] PersonRequest newPerson)
    {
        var person = new Person(HierarchyId.Parse(newPerson.Path), newPerson.Name);
        
        _context.Add(person);
        await _context.SaveChangesAsync();

        return Ok(person);
    }
}
