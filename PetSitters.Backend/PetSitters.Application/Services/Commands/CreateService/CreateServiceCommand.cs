using System;
using MediatR;

namespace PetSitters.Application.Services.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

    }
}
