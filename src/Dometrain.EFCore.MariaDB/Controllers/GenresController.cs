using Dometrain.EFCore.MariaDB.Models;
using Dometrain.EFCore.MariaDB.Repositories;
using Dometrain.EFCore.MariaDB.Services;
using Microsoft.AspNetCore.Mvc;
namespace Dometrain.EFCore.MariaDB.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : Controller
{
    private readonly IGenreRepository _repository;
    private readonly IBatchGenreService _batchService;

    public GenresController(IGenreRepository repository, IBatchGenreService batchService)
    {
        _repository = repository;
        _batchService = batchService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAll());
    }
    
    [HttpGet("from-query")]
    [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllFromQuery()
    {
        return Ok(await _repository.GetAllFromQuery());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var genre = await _repository.Get(id);
        
        return genre == null
            ? NotFound()
            : Ok(genre);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Genre), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] Genre genre)
    {
        var createdGenre = await _repository.Create(genre);

        return CreatedAtAction(nameof(Get), new { id = createdGenre.Id }, createdGenre);
    }
    
    [HttpPost("batch")]
    [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAll([FromBody] List<Genre> genres)
    {
        var response = await _batchService.CreateGenres(genres);

        return CreatedAtAction(nameof(GetAll), new{}, response);
    }
    
    [HttpPut("batch-update")]
    [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status201Created)]
    public async Task<IActionResult> UpdateAll([FromBody] List<Genre> genres)
    {
        var response = await _batchService.UpdateGenres(genres);

        return CreatedAtAction(nameof(GetAll), new{}, response);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Genre genre)
    {
        var updatedGenre = await _repository.Update(id, genre);

        return updatedGenre is null
            ? NotFound()
            :Ok(updatedGenre);
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var success = await _repository.Delete(id);
        
        return success ? Ok() : NotFound();
    }
}