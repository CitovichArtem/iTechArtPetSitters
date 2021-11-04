using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PetSitters.Application.PetSitters.Commands.CreatePetSitter
{
    public class CreatePetSitterCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
