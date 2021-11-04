using AutoMapper;
using PetSitters.Application.Services.Commands.CreateService;
using PetSitters.Application.Common.Mappings;

namespace PetSitters.WebApi.Models
{
    public class CreateServiceDto : IMapWith<CreateServiceCommand>
    {
        public string Name { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateServiceDto, CreateServiceCommand>()
                .ForMember(serviceCommand => serviceCommand.Name,
                    opt => opt.MapFrom(serviceDto => serviceDto.Name))
                .ForMember(serviceCommand => serviceCommand.Details,
                    opt => opt.MapFrom(serviceDto => serviceDto.Details));
        }
    }
}