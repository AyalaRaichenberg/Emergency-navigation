using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Repositories
{
    public interface IEdgeRepository
    {
        public List<Edge> GetEdgeList();
        public Edge GetEdgeById(long id);
        public Edge AddEdge(Edge edge);
        public Edge UpdateEdge(Edge edge);
        public void DeleteEdge(long id);





    }
}