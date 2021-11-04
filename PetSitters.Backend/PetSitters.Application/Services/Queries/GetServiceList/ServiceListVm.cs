using System.Collections.Generic;

namespace PetSitters.Application.Services.Queries.GetServiceList
{
    public class ServiceListVm
    {
        public IList<ServiceLookupDto> Services { get; set; }
    }
}
