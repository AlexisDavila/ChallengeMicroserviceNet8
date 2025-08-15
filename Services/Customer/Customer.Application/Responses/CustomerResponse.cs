using System;

namespace Customer.Application.Responses;

public class CustomerResponse
{
   public int Id { get; set; }
   public string? Name { get; set; }
   public string? Address { get; set; }
   public string? Phone { get; set; }
   public string? Password { get; set; }
   public bool? Status { get; set; }
}
