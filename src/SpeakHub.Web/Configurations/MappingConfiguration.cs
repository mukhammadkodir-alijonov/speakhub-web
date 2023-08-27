using AutoMapper;
using SpeakHub.Domain.Entities.Admins;
using SpeakHub.Service.Dtos.Admins;

namespace SpeakHub.Web.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AdminRegisterDto, Admin>().ReverseMap();
        }
    }
}
