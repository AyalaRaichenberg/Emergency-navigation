using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Model
{
    public class Floor
    {
        public long Id {  get; set;  }
        public int FloorNumber { get; set; }
        public long BuildingId { get; set; }
        public Building? Building { get; set; }
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();
    }
}
