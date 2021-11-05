using System;
using MediatR;

namespace PetSitters.Application.Pets.Commands.DeletePet
{
    public class DeletePetCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}