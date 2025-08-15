using System;

namespace Customer.Application.Exceptions;

public class CustomerNotFoundException : ApplicationException
{
   public CustomerNotFoundException(string name, Object key)
      : base($"Entity {name} - {key} was not found.") {}
}