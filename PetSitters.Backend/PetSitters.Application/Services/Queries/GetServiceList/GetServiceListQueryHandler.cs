using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetSitters.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetSitters.Application.Services.Queries.GetServiceList
{
    public class GetServiceListQueryHandler
        : IRequestHandler<GetServiceListQuery, ServiceListVm>
    {
        private readonly IServicesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetServiceListQueryHandler(IServicesDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ServiceListVm> Handle(GetServiceListQuery request,
            CancellationToken cancellationToken)
        {
            var servicesQuery = await _dbContext.Services
                .Where(service => service.UserId == request.UserId)
                .ProjectTo<ServiceLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ServiceListVm { Services = servicesQuery };
        }
    }
}
