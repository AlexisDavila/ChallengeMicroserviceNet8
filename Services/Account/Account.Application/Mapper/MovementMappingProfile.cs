using System;
using Account.Application.Commands.Movement;
using Account.Application.Responses;
using Account.Domain.Entities;
using AutoMapper;

namespace Account.Application.Mapper;

public class MovementMappingProfile : Profile
{
   public MovementMappingProfile()
   {
      CreateMap<MovementEntity, MovementResponse>().ReverseMap();
      CreateMap<MovementEntity, CreateMovementCommand>().ReverseMap();

   }
}
