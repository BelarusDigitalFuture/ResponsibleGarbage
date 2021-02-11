using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Models
{
    public class GarbageType : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DumpsterGarbageType> Dumpsters { get; set; }

        public ICollection<ProductGarbageType> Products { get; set; }
    }
}
