namespace Dometrain.EFCore.MariaDB.Models;

public class Actor
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public List<Movie> Movies { get; set; } = new();
}