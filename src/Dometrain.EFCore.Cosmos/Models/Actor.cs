namespace Dometrain.EFCore.Cosmos.Models;

public class Actor
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}