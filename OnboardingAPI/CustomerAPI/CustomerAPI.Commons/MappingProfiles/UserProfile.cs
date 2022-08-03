using AutoMapper;
using CustomerAPI.CustomerAPI.Models;
using CustomerAPI.CustomerAPI.Models.DTOs;

namespace CustomerAPI.CustomerAPI.Commons.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Customer, CustomerToAddDTO>();
            CreateMap<Customer, CustomerToReturnDTO>();
        }
    }
}
