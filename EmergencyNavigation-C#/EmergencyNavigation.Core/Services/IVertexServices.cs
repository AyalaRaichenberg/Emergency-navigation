using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Services
{
    public interface IVertexServices
    {
        public List<Vertex> GetVertexList();
        public Vertex AddVertex(Vertex vertex);
        public Vertex GetVertexById(long id);
        public Vertex UpdateVertex(Vertex vertex);
        public void DeleteVertex(long id);
        public void AddEdge(Edge edge, long id);
        public List<Vertex> GetListByBuildingAndFloor(long buildingId, int floorNumber);
    }
}
