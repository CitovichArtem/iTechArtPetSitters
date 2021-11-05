using System;
using MediatR;

namespace PetSitters.Application.Pets.Queries.GetPetList
{
    public class GetPetListQuery : IRequest<PetListVm>
    {
        public Guid UserId { get; set; }
    }
}
