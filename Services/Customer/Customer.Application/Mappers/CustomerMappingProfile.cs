using System;
using AutoMapper;
using Customer.Application.Commands;
using Customer.Application.Responses;
using Customer.Domain.Entities;

namespace Customer.Application.Mappers;

public class CustomerMappingProfile:Profile
{
   public CustomerMappingProfile()
   {
      CreateMap<CustomerEntity, CustomerResponse>().ReverseMap();
      CreateMap<CustomerEntity,CreateCustomerCommand>().ReverseMap();
      CreateMap<CustomerEntity,UpdateCustomerCommand>().ReverseMap();
      CreateMap<CustomerEntity,DeleteCustomerCommand>().ReverseMap();
   }
}
