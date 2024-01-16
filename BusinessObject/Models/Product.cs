using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject.Models;

public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public int CategoryId { get; set; }
    [Required] [StringLength(100)] public string Name { get; set; } = null!;
    [Required] [Precision(4, 2)] public decimal Weight { get; set; }
    [Required] [Precision(4, 2)] public decimal UnitPrice { get; set; }
    [Required] public int UnitInStock { get; set; }

    public Category? Category { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}