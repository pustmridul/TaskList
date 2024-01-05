using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace TaskList
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();

            CreateMap<Account, AccountDto>();

            CreateMap<OwnerForCreationDto, Owner>();

            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
