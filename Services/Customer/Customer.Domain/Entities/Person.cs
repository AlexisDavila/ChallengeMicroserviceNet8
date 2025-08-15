using Customer.Domain.common;
using Customer.Domain.Enum;

namespace Customer.Domain.Entities;

public class Person : EntityBase
{
   public string? Name { get; set; }
   public Gender? Gender { get; set; }
   public string? Identification { get; set; }
   public string? Address { get; set; }
   public string? Phone { get; set; }
   
}
