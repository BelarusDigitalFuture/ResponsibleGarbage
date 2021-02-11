using System;
using System.Collections.Generic;
using System.Text;

namespace Responsiblegarbage.Shared
{
    public class GarbageTypeDto
    {
        public GarbageTypeDto()
        {

        }

        public GarbageTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
