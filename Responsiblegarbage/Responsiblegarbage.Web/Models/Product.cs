using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public int CompanyId { get; set; }

        public string Image { get; set; }

        public Company Company { get; set; }
    }
}
