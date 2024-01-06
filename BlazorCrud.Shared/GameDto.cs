using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Shared;

public class GameDto
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}