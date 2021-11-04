using System;
using AutoMapper;
using PetSitters.Domain;
using PetSitters.Application.Common.Mappings;

namespace PetSitters.Application.Services.Queries.GetServiceDetails
{
    public class ServiceDetailsVm : IMapWith<Service>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Service, ServiceDetailsVm>()
                .ForMember(serviceVm => serviceVm.Name,
                    opt => opt.MapFrom(service => service.Name))
                .ForMember(serviceVm => serviceVm.Details,
                    opt => opt.MapFrom(service => service.Details))
                .ForMember(serviceVm => serviceVm.Id,
                    opt => opt.MapFrom(service => service.Id));
        }
    }
}