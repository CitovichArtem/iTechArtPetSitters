using System;
using AutoMapper;
using PetSitters.Application.Common.Mappings;
using PetSitters.Domain;

namespace PetSitters.Application.PetSitters.Queries.GetPetSitterList
{
    public class PetSitterLookupDto : IMapWith<PetSitter>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PetSitter, PetSitterLookupDto>()
                .ForMember(petsitterDto => petsitterDto.Id,
                    opt => opt.MapFrom(petsitter => petsitter.Id))
                .ForMember(petsitterDto => petsitterDto.Name,
                    opt => opt.MapFrom(petsitter => petsitter.Name));
        }
    }
}
