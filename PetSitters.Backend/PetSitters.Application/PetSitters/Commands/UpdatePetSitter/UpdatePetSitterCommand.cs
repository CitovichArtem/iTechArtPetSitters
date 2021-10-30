using System;
using MediatR;

namespace PetSitters.Application.PetSitters.Commands.UpdatePetSitter
{
    public class UpdatePetSitterCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
