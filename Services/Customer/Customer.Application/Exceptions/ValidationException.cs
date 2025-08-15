using FluentValidation.Results;

namespace Customer.Application.Exceptions;

public class ValidationException : ApplicationException
{
   public Dictionary<string, string[]> Errors { get; }

   public ValidationException()
      : base("One or more validation error(s) occurred.")
   {
      Errors = new Dictionary<string, string[]>();
   }
   public ValidationException(IEnumerable<ValidationFailure> failures) : this()
   {
      Errors = failures
      .GroupBy(f => f.PropertyName, f => f.ErrorMessage)
         .ToDictionary(f => f.Key, f => f.ToArray());
   }
}
