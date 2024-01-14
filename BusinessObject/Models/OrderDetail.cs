using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models;

public class OrderDetail
{
    [Key] [Required] public int OrderId { get; set; }
    [Key] [Required] public int ProductId { get; set; }
    [Required] public decimal UnitPrice { get; set; }
    [Required] public int Quantity { get; set; }
    [Required] public double Discount { get; set; }

    public Product? Product { get; set; }
    public Order? Order { get; set; }
}