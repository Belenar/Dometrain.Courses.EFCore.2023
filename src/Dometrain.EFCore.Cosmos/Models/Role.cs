namespace Dometrain.EFCore.Cosmos.Models;

public class Role
{
    public required string CharacterName { get; set; }
    public Actor Actor { get; set; }
}