using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSitters.Domain
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Mark{ get; set; }
        public PetSitter PetSitterId { get; set; }
        public User UserId { get; set; }
    }
}
