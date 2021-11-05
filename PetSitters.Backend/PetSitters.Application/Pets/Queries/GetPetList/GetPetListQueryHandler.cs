using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetSitters.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetSitters.Application.Pets.Queries.GetPetList
{
    public class GetPetListQueryHandler
        : IRequestHandler<GetPetListQuery, PetListVm>
    {
        private readonly IServicesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPetListQueryHandler(IServicesDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PetListVm> Handle(GetPetListQuery request,
            CancellationToken cancellationToken)
        {
            var petsQuery = await _dbContext.Pets
                .Where(pet => pet.UserId == request.UserId)
                .ProjectTo<PetLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PetListVm { Pets = petsQuery };
        }
    }
}
