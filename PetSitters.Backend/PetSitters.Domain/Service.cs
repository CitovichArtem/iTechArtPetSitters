using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSitters.Domain
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int PetId { get; set; }
        public Guid UserId{ get; set; }
        public User User { get; set; }
        public Pet Pet { get; set; }
    }
}
