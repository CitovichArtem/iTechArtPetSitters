using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PetSitters.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetSitters.Application.Common.Exceptions;
using PetSitters.Domain;

namespace PetSitters.Application.Services.Queries.GetServiceDetails
{
    public class GetServiceDetailsQueryHandler
    : IRequestHandler<GetServiceDetailsQuery, ServiceDetailsVm>
    {
        private readonly IServicesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetServiceDetailsQueryHandler(IServicesDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ServiceDetailsVm> Handle(GetServiceDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Services
                .FirstOrDefaultAsync(service =>
                service.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Service), request.Id);
            }

            return _mapper.Map<ServiceDetailsVm>(entity);
        }
    }
}
