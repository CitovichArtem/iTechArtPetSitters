using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetSitters.Application.Interfaces;
using PetSitters.Application.Common.Exceptions;
using PetSitters.Domain;

namespace PetSitters.Application.PetSitters.Commands.UpdatePetSitter
{
    public class UpdatePetSitterCommandHandler
        : IRequestHandler<UpdatePetSitterCommand>
    {
        private readonly IPetSittersDbContext _dbContext;
        public UpdatePetSitterCommandHandler(IPetSittersDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdatePetSitterCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.PetSitters.FirstOrDefaultAsync(petsitter =>
                petsitter.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(PetSitter), request.Id);
            }
            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
