namespace Dometrain.EFCore.Cosmos.Models;

public class Movie
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public required string Synopsis { get; set; }

    public required Genre Genre { get; set; }
    
    public List<Role> Characters { get; set; } = new();
}

public class Role
{
    public required string CharacterName { get; set; }
    public Actor Actor { get; set; }
}

public class Genre
{
    public required string Name { get; set; }
    public required string Description { get; set; }
}

public class Actor
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public List<Movie> Movies { get; set; } = new();
}