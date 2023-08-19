using AutoMapper;
using Entities.Models;
using Shared.DTO_s;

namespace UltimateWebApplication.MappingServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Company, CompanyDto>()
                .ForMember(x=>x.FullAddress, opt=>opt.MapFrom(src => 
                string.Join( ' ', src.Address, src.Country) ));
        }
    }
}
