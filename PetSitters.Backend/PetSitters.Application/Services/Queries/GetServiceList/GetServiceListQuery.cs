using System;
using MediatR;

namespace PetSitters.Application.Services.Queries.GetServiceList
{
    public class GetServiceListQuery : IRequest<ServiceListVm>
    {
        public Guid UserId { get; set; }
    }
}
