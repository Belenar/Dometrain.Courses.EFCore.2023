using Dometrain.EFCore.API.Data.EntityMapping;
using Dometrain.EFCore.API.Data.Interceptors;
using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.API.Data;

public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }
    
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<ExternalInformation> ExternalInformations => Set<ExternalInformation>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<GenreName> GenreNames => Set<GenreName>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreMapping());
        modelBuilder.ApplyConfiguration(new MovieMapping());
        modelBuilder.ApplyConfiguration(new CinemaMovieMapping());
        modelBuilder.ApplyConfiguration(new TelevisionMovieMapping());
        modelBuilder.ApplyConfiguration(new ExternalInformationMapping());
        modelBuilder.ApplyConfiguration(new ActorMapping());

        modelBuilder.Entity<GenreName>()
            .HasNoKey()
            .ToSqlQuery($"SELECT Name FROM dbo.Genres");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SaveChangesInterceptor());
    }
}