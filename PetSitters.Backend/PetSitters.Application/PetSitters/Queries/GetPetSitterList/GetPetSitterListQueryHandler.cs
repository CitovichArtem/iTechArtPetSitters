using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetSitters.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetSitters.Application.PetSitters.Queries.GetPetSitterList
{
    public class GetPetSitterListQueryHandler
        : IRequestHandler<GetPetSitterListQuery, PetSitterListVm>
    {
        private readonly IPetSittersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPetSitterListQueryHandler(IPetSittersDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PetSitterListVm> Handle(GetPetSitterListQuery request,
            CancellationToken cancellationToken)
        {
            var petsittersQuery = await _dbContext.PetSitters
                .Where(petsitter => petsitter.Id == request.Id)
                .ProjectTo<PetSitterLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PetSitterListVm { PetSitters = petsittersQuery };
        }
    }
}
