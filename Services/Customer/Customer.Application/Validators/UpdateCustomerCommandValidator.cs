using System;
using Customer.Application.Commands;
using FluentValidation;

namespace Customer.Application.Validators;

public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
{
   public UpdateCustomerCommandValidator()
   {
      RuleFor(x => x.Id)
         .NotEmpty()
         .NotNull()
         .WithMessage("{Id} is required.")
         .GreaterThan(0)
         .WithMessage("{Id} must be greater than 0.");
      RuleFor(c => c.Name)
         .NotEmpty()
         .WithMessage("{Name} is required.")
         .NotNull()
         .MaximumLength(70)
         .WithMessage("{Name} must not exceed 70 characters.");
      RuleFor(c => c.Address)
         .NotEmpty()
         .WithMessage("{Address} is required.")
         .NotNull()
         .MaximumLength(100)
         .WithMessage("{Address} must not exceed 150 characters.");
      RuleFor(c => c.Phone)
         .NotEmpty()
         .WithMessage("{Phone} is required.")
         .NotNull()
         .MaximumLength(9)
         .WithMessage("{Phone} must not exceed 9 numbers.");
      RuleFor(c => c.Password)
         .NotEmpty()
         .WithMessage("{Password} is required.")
         .NotNull();
      RuleFor(c => c.Status)
         .NotEmpty()
         .WithMessage("{Status} is required.")
         .NotNull();

        
    }
}