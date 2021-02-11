using System;
using System.Collections.Generic;
using System.Text;

namespace Responsiblegarbage.Shared
{
    public class DumpsterDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public List<GarbageTypeDto> Types { get; set; }
    }
}
