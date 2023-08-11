using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dometrain.EFCore.API.Models;

[Table("Pictures")]
public class Movie
{
    [Key]
    public int Identifier { get; set; }
    
    [MaxLength(128)]
    [Column(TypeName = "varchar")]
    [Required]
    public string? Title { get; set; }  
    
    [Column(TypeName = "date")]
    public DateTime ReleaseDate { get; set; }
    
    [Column("Plot", TypeName = "varchar(max)")]
    public string? Synopsis { get; set; }
}

public class MovieTitle
{
    public int Id { get; set; }
    public string? Title { get; set; }  
}