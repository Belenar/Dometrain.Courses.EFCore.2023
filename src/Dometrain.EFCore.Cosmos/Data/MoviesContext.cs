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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .ToContainer("Movies");

        modelBuilder.Entity<Movie>()
            .OwnsOne(movie => movie.Genre);
        
        modelBuilder.Entity<Movie>()
            .OwnsMany(movie => movie.Characters);
        
        modelBuilder.Entity<Actor>()
            .ToContainer("Actors");
    }
}