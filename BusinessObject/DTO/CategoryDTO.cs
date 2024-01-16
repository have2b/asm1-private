using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTO;

public class CategoryDTO
{
    [Required] [MaxLength(100)] public string Name { get; set; } = null!;
}