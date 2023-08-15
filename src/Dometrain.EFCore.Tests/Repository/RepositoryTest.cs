using Dometrain.EFCore.SimpleAPI.Controllers;
using Dometrain.EFCore.SimpleAPI.Data;
using Dometrain.EFCore.SimpleAPI.Models;
using Dometrain.EfCore.SimpleAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Dometrain.EFCore.Tests.Repository;

public class RepositoryTest
{
    [Fact]
    public async Task IfGenreExists_ReturnsGenre()
    {
        // Arrange
        var controller = new GenresWithRepositoryController(null);
        
        // Act
        var response = await controller.Get(2);
        var okResult = response as OkObjectResult;
        
        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal("Action", (okResult.Value as Genre)?.Name);
    }
}