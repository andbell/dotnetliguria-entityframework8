using DotNetLiguria.EF8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF8.WebApi.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class MoviesController : ControllerBase
//{
//    private readonly MovieContext _context;

//    public MoviesController(MovieContext context)
//    {
//        _context = context;
//    }

//    [HttpPost("movie")]
//    public async Task<ActionResult<Movie>> AddMovie()
//    {
//        var newMovie = new Movie
//        {
//            Title = "Interstellar",
//            SerieTV = false,
//            Abstract = "One of the best movie ever!",
//            Info = new MovieInfo
//            {
//                Duration = 160,
//                Nationality = "USA",
//                Rated = "NO",
//                Year = 2014,
//                Genres = "Fantascience, Adventure, Drama"
//            },
//            Cast = new Cast
//            {
//                Actors = new List<Person>
//                {
//                    new Person { FullName = "Matthew McConaughey" },
//                    new Person { FullName = "Anne Hathaway" },
//                    new Person { FullName = "Jessica Chastain" },
//                },
//                Directors = new List<Person>
//                {
//                    new Person { FullName = "Christopher Nolan" },
//                }
//            }
//        };
//        _context.Add(newMovie);
//        await _context.SaveChangesAsync();
        
//        return Ok(newMovie);
//    }

//    [HttpPost("serietv")]
//    public async Task<ActionResult<Movie>> AddSerieTv()
//    {
//        var newSerieTv = new SerieTv
//        {
//            Title = "Dark",
//            SerieTV = true,
//            Abstract = "One of the best serie TV ever!",
//            Info = new MovieInfo
//            {
//                Duration = 45,
//                Nationality = "German",
//                Rated = "14",
//                Year = 2018,
//                Genres = "Fantasy, Horror"
//            },
//            Cast = new Cast
//            {
//                Actors = new List<Person>
//            {
//                new Person { FullName = "Louis Hofmann" },
//                new Person { FullName = "Maja Sch�ne" },
//                new Person { FullName = "J�rdis Triebel" },
//            },
//                Directors = new List<Person>
//            {
//                new Person { FullName = "Baran bo Odar" },
//            }
//            },
//            Seasons = new Seasons
//            {
//                Episodes = new List<Episode>
//            {
//                new Episode { Title = "Episode 1", Duration = 45, Number = 1, Season = 1 },
//                new Episode { Title = "Episode 2", Duration = 45, Number = 2, Season = 2 },
//            }
//            }
//        };
//        _context.Add(newSerieTv);
//        await _context.SaveChangesAsync();

//        return Ok(newSerieTv);
//    }

//    [HttpGet]
//    public async Task<ActionResult<List<Movie>>> GetAllMovies()
//    {
//        var movies = await _context.Movies.Select(x => new {x.Id, x.Title, x.Info.Year}).ToListAsync();
//        return Ok(movies);
//    }

//    [HttpGet("find")]
//    public async Task<ActionResult<List<Movie>>> FindMovies([FromQuery] string? title, [FromQuery] string? actor, [FromQuery] int? year, [FromQuery] int? minDuration)
//    {
//        var query = _context.Movies.AsQueryable();

//        if (title is not null)
//            query = query.Where(x => x.Title.Contains(title));

//        if (minDuration is not null)
//            query = query.Where(x => x.Info.Duration >= minDuration);

//        if (year.HasValue)
//            query = query.Where(x => x.Info.Year == year.Value);

//        // THIS THROW AN EXCEPTION AT RUNTIME
//        if (actor is not null)
//            query = query.Where(x => x.Cast.Actors.Any(a => a.FullName.Contains(actor)));

//        var movies = await query.Select(x => new { x.Id, x.Title, x.Info.Year }).ToListAsync();
//        return Ok(movies);
//    }

//    [HttpGet("{movieId:int}")]
//    public async Task<ActionResult<Movie>> GetMovieById(int movieId)
//    {
//        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);

//        if (movie is null)
//            return NotFound();

//        Console.WriteLine($"Movie '{movie.Title}' was retrieved at '{movie.Retrieved.ToLocalTime()}'");
//        return Ok(movie);
//    }

//    [HttpDelete]
//    public async Task<ActionResult<List<Movie>>> DeleteMovie(int movieId)
//    {
//        await _context.Movies.Where(m => m.Id == movieId).ExecuteDeleteAsync();
//        return NoContent();
//    }

//    [HttpPut("bulk")]
//    public async Task<ActionResult> UpdateMovieBulk()
//    {
//        await _context.Movies.Where(m => m.Info.Year == 2020).ExecuteUpdateAsync(u => u.SetProperty(p => p.Title, c => $"{c.Title} (2020)"));
//        return NoContent();
//    }

//    [HttpPut("{movieId:int}")]
//    public async Task<ActionResult<Movie>> UpdateMovie(int movieId)
//    {
//        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == movieId);

//        if (movie is null)
//            return NotFound();

//        movie.Info.Duration = 100;
//        movie.Cast.Actors.Add(new Person { FullName = "Andrea Belloni" });

//        await _context.SaveChangesAsync();

//        return Ok(movie);
//    }
//}