using System.Collections.Generic;

namespace PetSitters.Application.PetSitters.Queries.GetPetSitterList
{
    public class PetSitterListVm
    {
        public IList<PetSitterLookupDto> PetSitters { get; set; }
    }
}
