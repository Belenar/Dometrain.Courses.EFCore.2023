using Dometrain.EFCore.Tenants.QueryFilter.Data;
using Dometrain.EFCore.Tenants.QueryFilter.Models;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.Tenants.QueryFilter.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAll();
    Task<Genre?> Get(int id);
    Task<Genre> Create(Genre genre);
    Task<Genre?> Update(int id, Genre genre);
    Task<bool> Delete(int id);
}

public class GenreRepository: IGenreRepository
{
    private readonly MoviesContext _context;

    public GenreRepository(MoviesContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Genre>> GetAll()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<Genre?> Get(int id)
    {
        return await _context.Genres.FindAsync(id);
    }

    public async Task<Genre> Create(Genre genre)
    {
        await _context.Genres.AddAsync(genre);

        _context.Entry(genre)
            .Property<string?>("TenantId")
            .CurrentValue = _context.TenantId;
        
        await _context.SaveChangesAsync();

        return genre;
    }

    public async Task<Genre?> Update(int id, Genre genre)
    {
        var existingGenre = await _context.Genres.FindAsync(id);

        if (existingGenre is null)
            return null;

        existingGenre.Name = genre.Name;

        await _context.SaveChangesAsync();

        return existingGenre;
    }

    public async Task<bool> Delete(int id)
    {
        var existingGenre = await _context.Genres.FindAsync(id);

        if (existingGenre is null)
            return false;

        _context.Genres.Remove(existingGenre);

        await _context.SaveChangesAsync();
        return true;
    }
}