using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Model
{
    public class Edge
    {
            public long Id { get; set; }
            public long SourceId { get; set; }
            public Vertex? Source { get; set; }
            public long VertexId {  get; set; }
            public Vertex ?Vertex { get; set; }
            public double Meters { get; set; }
      
    }
}
