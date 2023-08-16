using Dometrain.EFCore.Tenants.QueryFilter.Models;
using Dometrain.EFCore.Tenants.QueryFilter.Repositories;
using Dometrain.EFCore.Tenants.QueryFilter.Tenants;
using Microsoft.AspNetCore.Mvc;

namespace Dometrain.EFCore.Tenants.QueryFilter.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : Controller
{
    private readonly IGenreRepository _repository;

    public GenresController(IGenreRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAll());
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