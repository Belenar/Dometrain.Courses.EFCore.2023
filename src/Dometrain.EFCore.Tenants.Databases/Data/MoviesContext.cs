using Dometrain.EFCore.Tenants.Databases.Data.EntityMapping;
using Dometrain.EFCore.Tenants.Databases.Models;
using Dometrain.EFCore.Tenants.Databases.Tenants;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.Tenants.Databases.Data;

public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options)
        :base(options)
    { }
    
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreMapping());
    }
}