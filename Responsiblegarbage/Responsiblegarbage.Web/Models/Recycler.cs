using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Models
{
    public class Recycler : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Dumpster> Dumpsters { get; set; }
    }
}
