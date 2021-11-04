using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSitters.Domain
{
    public class Application
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int PetId { get; set; }
        public Service Service { get; set; }
        public Pet Pet { get; set; }
    }
}
