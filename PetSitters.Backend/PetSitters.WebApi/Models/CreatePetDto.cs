using AutoMapper;
using PetSitters.Application.Pets.Commands.CreatePet;
using PetSitters.Application.Common.Mappings;

namespace PetSitters.WebApi.Models
{
    public class CreatePetDto : IMapWith<CreatePetCommand>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePetDto, CreatePetCommand>()
                .ForMember(petCommand => petCommand.Name,
                    opt => opt.MapFrom(petDto => petDto.Name))
                .ForMember(petCommand => petCommand.Age,
                    opt => opt.MapFrom(petDto => petDto.Age));
        }
    }
}