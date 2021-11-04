using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetSitters.Application.Interfaces;
using PetSitters.Domain;

namespace PetSitters.Application.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler
        : IRequestHandler<CreateServiceCommand, Guid>
    {
        private readonly IServicesDbContext _dbContext;
        public CreateServiceCommandHandler(IServicesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateServiceCommand request,
            CancellationToken cancellationToken)
        {
            var service = new Service
            {
                UserId = request.UserId,
                Name = request.Name,
                Details = request.Details,
                Id = Guid.NewGuid()

            };

            await _dbContext.Services.AddAsync(service, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return service.Id;
        }
    }
}
