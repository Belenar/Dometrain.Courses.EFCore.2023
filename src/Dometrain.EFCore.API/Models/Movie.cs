namespace Dometrain.EFCore.API.Models;

public abstract class Movie
{
    public int Identifier { get; set; }
    public string? Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Synopsis { get; set; }
    public AgeRating AgeRating { get; set; }

    public decimal InternetRating { get; set; }
    
    // public Person Director { get; set; }
    // public ICollection<Person> Actors { get; set; }

    public Genre Genre { get; set; }
    public int MainGenreId { get; set; }
}

public class CinemaMovie : Movie
{
    public required decimal GrossRevenue { get; set; }
}

public class TelevisionMovie : Movie
{
    public required string ChannelFirstAiredOn { get; set; }
}