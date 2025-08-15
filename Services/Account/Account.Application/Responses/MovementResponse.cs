using System;
using System.ComponentModel.DataAnnotations;

namespace Account.Application.Responses;

public class MovementResponse
{
   [Key]
   public int Id { get; set; }
   public DateTime? Date { get; set; }
   public Type? Type { get; set; }
   public decimal? Value { get; set; }
   public decimal? Balance { get; set; }
   public int? AccountId { get; set; }
}
