using System;
using MediatR;

namespace PetSitters.Application.Services.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}