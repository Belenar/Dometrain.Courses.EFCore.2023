using Dometrain.EFCore.MariaDB.Data;
using Dometrain.EFCore.MariaDB.Models;
using Dometrain.EFCore.MariaDB.Repositories;

namespace Dometrain.EFCore.MariaDB.Services;

public interface IBatchGenreService
{
    Task<IEnumerable<Genre>> CreateGenres(IEnumerable<Genre> genres);
    Task<IEnumerable<Genre>> UpdateGenres(IEnumerable<Genre> genres);
}

public class BatchGenreService : IBatchGenreService
{
    private readonly IGenreRepository _repository;
    private readonly IMoviesContextManager _manager;

    public BatchGenreService(IGenreRepository repository, IMoviesContextManager manager)
    {
        _repository = repository;
        _manager = manager;
    }
    
    public async Task<IEnumerable<Genre>> CreateGenres(IEnumerable<Genre> genres)
    {
        List<Genre> response = new ();
        _manager.StartUnitOfWork();
        foreach (var genre in genres)
        {
            response.Add(await _repository.Create(genre));
        }
        await _manager.SaveChangesAsync();
        return response;
    }

    public async Task<IEnumerable<Genre>> UpdateGenres(IEnumerable<Genre> genres)
    {
        List<Genre> response = new ();
        _manager.StartUnitOfWork();

        var existingGenres = await _repository.GetAll(genres.Select(g => g.Id));
        
        foreach (var genre in genres)
        {
            var updatedGenre = await _repository.Update(genre.Id, genre);
            if(updatedGenre is not null)
                response.Add(updatedGenre);
        }
        await _manager.SaveChangesAsync();
        return response;
    }
}