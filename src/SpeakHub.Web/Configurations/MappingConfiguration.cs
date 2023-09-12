using AutoMapper;
using SpeakHub.Domain.Entities.Admins;
using SpeakHub.Domain.Entities.Users;
using SpeakHub.Service.Dtos.Accounts;
using SpeakHub.Service.Dtos.Admins;

namespace SpeakHub.Web.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AdminRegisterDto, Admin>().ReverseMap();
            CreateMap<AccountRegisterDto, User>().ReverseMap();
        }
    }
}
