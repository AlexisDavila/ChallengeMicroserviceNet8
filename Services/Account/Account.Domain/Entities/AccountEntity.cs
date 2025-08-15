using System;
using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Entities;

public class AccountEntity
{
   [Key]
   [Required]
   public int Id { get; set; }
   public string Number { get; set; }
   public Type Type { get; set; }
   public decimal InitialBalance { get; set; }
   public bool Status { get; set; }
   public int CustomerId { get; set; }
}
