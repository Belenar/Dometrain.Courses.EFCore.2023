using System.Text.Json.Serialization;

namespace Dometrain.EFCore.API.Models;

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }

    [JsonIgnore]
    public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
}

public class GenreName
{
    public required string Name { get; set; }
}