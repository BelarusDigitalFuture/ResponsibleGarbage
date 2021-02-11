using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Models
{
    public class ProductGarbageType
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int TypeId { get; set; }

        public GarbageType Type { get; set; }
    }
}
