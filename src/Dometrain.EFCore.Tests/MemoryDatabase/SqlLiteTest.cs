using Dometrain.EFCore.SimpleAPI.Controllers;
using Dometrain.EFCore.SimpleAPI.Data;
using Dometrain.EFCore.SimpleAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dometrain.EFCore.Tests.MemoryDatabase;

public class SqlLiteTest : IDisposable
{
    public SqlLiteTest()
    {
        // Test setup
    }
    
    public void Dispose()
    {
        // Test teardown
    }
    
    [Fact]
    public async Task IfGenreExists_ReturnsGenre()
    {
        // Arrange
        var context = CreateInMemoryContext();
        var controller = new GenresController(context);
        
        // Act
        var response = await controller.Get(2);
        var okResult = response as OkObjectResult;
        
        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal("Action", (okResult.Value as Genre)?.Name);
    }

    private MoviesContext CreateInMemoryContext()
    {
        throw new NotImplementedException();
    }
}