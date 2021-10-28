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
        public Service ServiceId { get; }
        public User UserId { get; }
    }
}
