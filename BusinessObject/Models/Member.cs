using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public class Member
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [EmailAddress] [StringLength(50)] public string Email { get; set; } = null!;
    [Required] [StringLength(100)] public string CompanyName { get; set; } = null!;
    [Required] [StringLength(50)] public string City { get; set; } = null!;
    [Required] [StringLength(50)] public string Country { get; set; } = null!;
    [Required] [StringLength(20)] public string Password { get; set; } = null!;

    public ICollection<Order> Orders { get; set; }
}