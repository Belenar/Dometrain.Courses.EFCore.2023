using System.Text.Json.Serialization;

namespace Dometrain.EFCore.MariaDB.Models;

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public byte[] ConcurrencyToken { get; set; } = new byte[0];

    [JsonIgnore]
    public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
}

public class GenreName
{
    public required string Name { get; set; }
}