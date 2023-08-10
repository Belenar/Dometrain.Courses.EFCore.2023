using Dometrain.EFCore.API.Data;
using Dometrain.EFCore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Dometrain.EFCore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : Controller
{
    private readonly MoviesContext _context;

    public MoviesController(MoviesContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<Movie>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Movies.ToListAsync());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        // Queries database, returns first match, null if not found.
        // var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        // Similar to FirstOrDefault, but throws if more than one match is found.
        // var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == id);
        // Serves match from memory if already fetched, otherwise queries DB.
        var movie = await _context.Movies.FindAsync(id);
        
        return movie == null
            ? NotFound()
            : Ok(movie);
    }
    
    [HttpGet("by-year/{year:int}")]
    [ProducesResponseType(typeof(List<Movie>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByYear([FromRoute] int year)
    {
        //var filteredMovies = _context.Movies
        //    .Where(m => m.ReleaseDate.Year == year);
        
        var filteredMovies = 
            from movie in _context.Movies
            where movie.ReleaseDate.Year == year
            select movie;

        return Ok(await filteredMovies.ToListAsync());
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        
        // movie has no ID
        
        await _context.SaveChangesAsync();
        
        // movie has an ID

        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Movie movie)
    {
        var existingMovie = await _context.Movies.FindAsync(id);

        if (existingMovie is null)
            return NotFound();

        existingMovie.Title = movie.Title;
        existingMovie.ReleaseDate = movie.ReleaseDate;
        existingMovie.Synopsis = movie.Synopsis;

        await _context.SaveChangesAsync();

        return Ok(existingMovie);
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var existingMovie = await _context.Movies.FindAsync(id);

        if (existingMovie is null)
            return NotFound();

        _context.Movies.Remove(existingMovie);
        // _context.Remove(existingMovie);
        // _context.Movies.Remove( new Movie { Id = id });

        await _context.SaveChangesAsync();

        return Ok();
    }
}