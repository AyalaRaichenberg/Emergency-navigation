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
    public class VertexService : IVertexServices
    {
        private readonly IVertexRepository _vertexRepository;
        private readonly IBuildingRepository _buildingRepository;

        public VertexService(IVertexRepository vertexRepository, IBuildingRepository buildingRepository)
        {
            _vertexRepository = vertexRepository;
            _buildingRepository = buildingRepository;
        }

        public List<Vertex> GetVertexList()
        {
            return _vertexRepository.GetVertexList();
        }

        public Vertex AddVertex(Vertex vertex)
        {
            return _vertexRepository.AddVertex(vertex);
        }

        public Vertex GetVertexById(long id)
        {
            return _vertexRepository.GetVertexById(id);
        }

        public Vertex UpdateVertex(Vertex vertex)
        {
            return _vertexRepository.UpdateVertex(vertex);
        }

        public void DeleteVertex(long id)
        {
            _vertexRepository.DeleteVertex(id);
        }

        public void AddEdge(Edge edge, long id)
        {
            Vertex vertex = GetVertexById(id);
            _vertexRepository.AddEdge(edge, vertex);
        }
        public List<Vertex> GetListByBuildingAndFloor(long buildingId, int floorNumber)
        {
            Floor floor = _buildingRepository.FloorsByBuildingIdWithOutCircles(buildingId)?.FirstOrDefault(f => f.FloorNumber == floorNumber);
            return floor?.Vertices ?? new List<Vertex>();
        }

    }
}
