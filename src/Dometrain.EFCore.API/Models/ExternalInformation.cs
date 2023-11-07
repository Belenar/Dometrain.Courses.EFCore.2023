namespace Dometrain.EFCore.API.Models;

public class ExternalInformation
{
    public int MovieId { get; set; }
    
    public string? ImdbUrl { get; set; }
    public string? RottenTomatoesUrl { get; set; }
    public string? TmdbUrl { get; set; }

    public Movie Movie { get; set; }
}