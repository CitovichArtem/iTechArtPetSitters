using System;
using MediatR;

namespace PetSitters.Application.Services.Queries.GetServiceDetails
{
    public class GetServiceDetailsQuery : IRequest<ServiceDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}