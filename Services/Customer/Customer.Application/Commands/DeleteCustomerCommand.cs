using System;
using MediatR;

namespace Customer.Application.Commands;

public class DeleteCustomerCommand : IRequest<Unit>
{
    public int Id { get; set; }
}