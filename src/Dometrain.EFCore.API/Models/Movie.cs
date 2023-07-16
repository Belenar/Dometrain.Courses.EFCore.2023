namespace Dometrain.EFCore.API.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }    
    public DateTime ReleaseDate { get; set; }
    public string? Synopsis { get; set; }
}