using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceInventory.Data
{
    public class SingleEntry
    {
        public string Name { get; set; }
        public double Count { get; set; }
        public UnitOfMeasure Unit { get; set; }
    }
}