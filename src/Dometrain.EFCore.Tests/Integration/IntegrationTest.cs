using Dometrain.EFCore.SimpleAPI.Controllers;
using Dometrain.EFCore.SimpleAPI.Data;
using Dometrain.EFCore.SimpleAPI.Models;
using Dometrain.EfCore.SimpleAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Dometrain.EFCore.Tests.Integration;

public class IntegrationTest
{
    private readonly MoviesContext _testContext;
    private readonly MoviesContext _verificationContext;

    public IntegrationTest()
    {
        var options = new DbContextOptionsBuilder<MoviesContext>()
            .UseSqlServer("""
                          Data Source=localhost;
                          Initial Catalog=TestDB;
                          User Id=sa;
                          Password=MySaPassword123;
                          TrustServerCertificate=True;
                          """)
            .Options;

        _testContext = new MoviesContext(options);
        _verificationContext = new MoviesContext(options);

        // Usually not needed, as a deploy of the test database
        // before the test run will migrate the schema.
        _testContext.Database.EnsureDeleted();
        _testContext.Database.EnsureCreated();
    }
    
    [Fact]
    public async Task WhenGenreCreated_GenreIsInDatabase()
    {
        // Arrange
        var repository = new GenreRepository(_testContext);
        
        // Act
        var genreToCreate = new Genre { Name = "MyAwesomeGenre" };
        var createdGenre = await repository.Create(genreToCreate);
        
        // Assert
        Assert.NotNull(createdGenre);
        Assert.True(createdGenre.Id > 0);
        var verificationGenre = _verificationContext.Genres.Find(createdGenre.Id);
        Assert.NotNull(verificationGenre);
        Assert.Equal(genreToCreate.Name, verificationGenre.Name);
    }
}