using System;
using MediatR;

namespace PetSitters.Application.PetSitters.Commands.DeletePetSitter
{
    public class DeletePetSitterCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}