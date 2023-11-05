using System.Text.Json.Serialization;

namespace Dometrain.EFCore.Cosmos.Models;

public class Role
{
    public required string CharacterName { get; set; }
    [JsonIgnore]
    public Guid ActorId { get; set; }
    public Actor Actor { get; set; }
}