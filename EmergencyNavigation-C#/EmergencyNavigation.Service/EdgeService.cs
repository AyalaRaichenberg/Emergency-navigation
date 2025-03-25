using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Repositories;
using EmergencyNavigation.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Service
{
    public class EdgeService : IEdgeService
    {
        private readonly IEdgeRepository _edgeRepository;

        public EdgeService(IEdgeRepository edgeRepository)
        {
            this._edgeRepository = edgeRepository;
        }

        public List<Edge> GetEdgeList()
        {
            return _edgeRepository.GetEdgeList();
        }
        public Edge AddEdge(Edge edge)
        {
            return _edgeRepository.AddEdge(edge);
        }

        public Edge GetEdgeById(long id)
        {
            return _edgeRepository.GetEdgeById(id);
        }

        public Edge UpdateEdge(Edge edge)
        {
            return _edgeRepository.UpdateEdge(edge);
        }

        public void DeleteEdge(long id)
        {
            _edgeRepository.DeleteEdge(id);
        }
    }
}