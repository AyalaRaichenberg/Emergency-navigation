using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Model
{
    public class Vertex
    {
        public long Id { get; set; }
        public int RoomNumber { get; set; }
        public long FloorId { get; set; }
        public Floor? Floor { get; set; }
        public long MainCharacterizationId { get; set; } 
        public VertexCharacterization? MainCharacterization { get; set; }
        public long SecondaryCharacterizationId { get; set; }
        public VertexCharacterization? SecondaryCharacterization { get; set; }
        public List<Edge> Edges { get; set; } = new List<Edge>();
        public List<User> Users { get; set; } = new List<User>();


        public override bool Equals(object obj)
        {
            if (obj is Vertex other)
                return this.Id == other.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
