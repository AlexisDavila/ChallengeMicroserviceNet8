using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Account.Application.Responses;

public class AccountResponse
{
   [Key]
   public int Id { get; set; }
   public string? Number { get; set; }
   public Type? Type { get; set; }
   public decimal? InitialBalance { get; set; }
   public bool? Status { get; set; }
   public int? CustomerId { get; set; }
}
