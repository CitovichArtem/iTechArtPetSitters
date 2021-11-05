using System;
using MediatR;

namespace PetSitters.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
