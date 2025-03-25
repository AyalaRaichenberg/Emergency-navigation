using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Services
{
    public interface IEdgeService
    {
        public List<Edge> GetEdgeList();
        public Edge AddEdge(Edge edge);
        public Edge GetEdgeById(long id);
        public Edge UpdateEdge(Edge edge);
        public void DeleteEdge(long id);
    }
}