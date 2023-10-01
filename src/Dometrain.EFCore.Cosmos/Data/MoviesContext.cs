using Dometrain.EFCore.Cosmos.Models;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.Cosmos.Data;

public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }
    
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Actor> Actors => Set<Actor>();
}