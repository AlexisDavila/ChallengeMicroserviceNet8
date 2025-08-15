using System;
using Customer.Application.Responses;
using MediatR;

namespace Customer.Application.Queries;

public class GetAllCustomersQuery : IRequest<List<CustomerResponse>>
{
}
