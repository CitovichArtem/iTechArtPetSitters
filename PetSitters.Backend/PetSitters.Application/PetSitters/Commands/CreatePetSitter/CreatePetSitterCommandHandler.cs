using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetSitters.Application.Interfaces;
using PetSitters.Domain;

namespace PetSitters.Application.PetSitters.Commands.CreatePetSitter
{
    public class CreatePetSitterCommandHandler
        : IRequestHandler<CreatePetSitterCommand, Guid>
    {
        private readonly IPetSittersDbContext _dbContext;
        public CreatePetSitterCommandHandler(IPetSittersDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreatePetSitterCommand request,
            CancellationToken cancellationToken)
        {
            var petsitter = new PetSitter
            {
                Id = request.Id,
                Name = request.Name,
                
            };

            await _dbContext.PetSitters.AddAsync(petsitter, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return petsitter.Id;
        }
    }
}
