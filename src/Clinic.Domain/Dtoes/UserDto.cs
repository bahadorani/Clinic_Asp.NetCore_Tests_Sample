using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Dtoes
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; } = null!;
        public string Family { get; } = null!;
        public string Tell { get; } = null!;
        public int CenterId { get; set; }
    }
}
