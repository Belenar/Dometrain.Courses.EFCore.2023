using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.API.Data;

public class MoviesContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=MoviesDB;User Id=sa;Password=MySaPassword123;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
}