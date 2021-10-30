using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetSitters.Application.Interfaces;
using PetSitters.Application.Common.Exceptions;
using PetSitters.Domain;

namespace PetSitters.Application.PetSitters.Commands.DeletePetSitter
{
    public class DeletePetSitterCommandHandler
        : IRequestHandler<DeletePetSitterCommand>
    {
        private readonly IPetSittersDbContext _dbContext;
        public DeletePetSitterCommandHandler(IPetSittersDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeletePetSitterCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.PetSitters
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(PetSitter), request.Id);
            }

            _dbContext.PetSitters.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
