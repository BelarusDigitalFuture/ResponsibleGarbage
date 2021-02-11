using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Models
{
    public class Dumpster : BaseEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Article
        /// </summary>
        public string Name { get; set; }

        public int RecyclerId { get; set; }

        public Recycler Recycler { get; set; }

        [Column(TypeName = "geometry (point)")]
        public Point Location { get; set; }

        public ICollection<DumpsterGarbageType> Types { get; set; }

    }
}
