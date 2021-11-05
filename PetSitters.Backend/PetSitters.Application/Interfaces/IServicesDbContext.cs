using Microsoft.EntityFrameworkCore;
using PetSitters.Domain;
using System.Threading;
using MediatR;
using System.Threading.Tasks;

namespace PetSitters.Application.Interfaces
{
    public interface IServicesDbContext
    {
        DbSet<Service> Services { get; set; }
        DbSet<Pet> Pets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
