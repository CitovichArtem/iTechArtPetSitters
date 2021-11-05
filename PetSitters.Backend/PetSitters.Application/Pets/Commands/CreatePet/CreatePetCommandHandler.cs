using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetSitters.Application.Interfaces;
using PetSitters.Domain;

namespace PetSitters.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommandHandler
        : IRequestHandler<CreatePetCommand, Guid>
    {
        private readonly IServicesDbContext _dbContext;
        public CreatePetCommandHandler(IServicesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreatePetCommand request,
            CancellationToken cancellationToken)
        {
            var pet = new Pet
            {
                UserId = request.UserId,
                Name = request.Name,
                Age = request.Age,
                Id = Guid.NewGuid()

            };

            await _dbContext.Pets.AddAsync(pet, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return pet.Id;
        }
    }
}