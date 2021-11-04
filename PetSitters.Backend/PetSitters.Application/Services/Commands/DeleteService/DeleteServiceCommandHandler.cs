using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetSitters.Application.Interfaces;
using PetSitters.Application.Common.Exceptions;
using PetSitters.Domain;

namespace PetSitters.Application.Services.Commands.DeleteService
{
    public class DeleteServiceCommandHandler
        : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IServicesDbContext _dbContext;
        public DeleteServiceCommandHandler(IServicesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteServiceCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Services
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Service), request.Id);
            }

            _dbContext.Services.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
