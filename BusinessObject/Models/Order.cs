using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject.Models;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public int MemberId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    [Required] public DateTime RequiredDate { get; set; }
    [Required] public DateTime ShippedDate { get; set; }
    [Required] [Precision(4, 2)] public decimal Freight { get; set; }
    
    public Member? Member { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}