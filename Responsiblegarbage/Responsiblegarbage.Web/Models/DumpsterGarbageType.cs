using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Models
{
    public class DumpsterGarbageType : BaseEntity
    {
        public int DumpsterId { get; set; }

        public int TypeId { get; set; }

        public Dumpster Dumpster { get; set; }

        public GarbageType Type { get; set; }
    }
}
