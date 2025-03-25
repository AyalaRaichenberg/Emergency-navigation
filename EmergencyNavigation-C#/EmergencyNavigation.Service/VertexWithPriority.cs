using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Service
{
    public class VertexWithPriority
    {
        public Vertex Vertex { get; set; }
        public double Priority { get;set; }

        public VertexWithPriority(Vertex vertex,double priority) 
        { 
            this.Vertex = vertex;
            this.Priority = priority;
        }
    }
}
