using System;
using AutoMapper;
using PetSitters.Application.Common.Mappings;
using PetSitters.Domain;

namespace PetSitters.Application.Services.Queries.GetServiceList
{
    public class ServiceLookupDto : IMapWith<Service>
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Service, ServiceLookupDto>()
                .ForMember(serviceDto => serviceDto.Id,
                    opt => opt.MapFrom(service => service.Id))
                .ForMember(serviceDto => serviceDto.Name,
                    opt => opt.MapFrom(service => service.Name));
        }
    }
}
