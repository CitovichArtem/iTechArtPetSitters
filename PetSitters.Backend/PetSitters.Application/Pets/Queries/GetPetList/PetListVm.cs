using System.Collections.Generic;

namespace PetSitters.Application.Pets.Queries.GetPetList
{
    public class PetListVm
    {
        public IList<PetLookupDto> Pets { get; set; }
    }
}
