﻿using System;
using AutoMapper;
using PetSitters.Application.Common.Mappings;
using PetSitters.Domain;

namespace PetSitters.Application.Pets.Queries.GetPetList
{
    public class PetLookupDto : IMapWith<Pet>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pet, PetLookupDto>()
                .ForMember(petDto => petDto.Id,
                    opt => opt.MapFrom(pet => pet.Id))
                .ForMember(petDto => petDto.Name,
                    opt => opt.MapFrom(pet => pet.Name));
        }
    }
}