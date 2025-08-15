using System;
using Account.Application.Commands.Account;
using Account.Application.Responses;
using Account.Domain.Entities;
using AutoMapper;

namespace Account.Application.Mapper;

public class AccountMappingProfile : Profile
{
   public AccountMappingProfile()
   {
      CreateMap<AccountEntity, AccountResponse>().ReverseMap();
      CreateMap<AccountEntity, CreateAccountCommand>().ReverseMap();
   }
}
