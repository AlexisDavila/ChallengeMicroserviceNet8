
namespace Customer.Domain.Entities;

public class CustomerEntity : Person
{
   public string? Password { get; set; }
   public bool? Status { get; set; }
}
