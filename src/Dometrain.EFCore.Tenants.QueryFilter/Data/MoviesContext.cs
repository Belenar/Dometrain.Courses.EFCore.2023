using Dometrain.EFCore.Tenants.QueryFilter.Data.EntityMapping;
using Dometrain.EFCore.Tenants.QueryFilter.Models;
using Dometrain.EFCore.Tenants.QueryFilter.Tenants;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.Tenants.QueryFilter.Data;

public class MoviesContext : DbContext
{
    private readonly TenantService _tenantService;

    public string? TenantId => _tenantService.GetTenantId(); 
    
    public MoviesContext(
        DbContextOptions<MoviesContext> options,
        TenantService tenantService)
        :base(options)
    {
        _tenantService = tenantService;
    }
    
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Not proper logging
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreMapping(this));
    }
}