using System;
using MediatR;

namespace PetSitters.Application.PetSitters.Queries.GetPetSitterList
{
    public class GetPetSitterListQuery : IRequest<PetSitterListVm>
    {
        public Guid Id { get; set; }
    }
}
