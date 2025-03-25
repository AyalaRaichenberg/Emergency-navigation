using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmergencyNavigation.Data.Repositories
{
    public class VertexRepository: IVertexRepository
    {
        private readonly DataContext _dataContext;

        public VertexRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Vertex> GetVertexList()
        {
            return _dataContext.Vertices.ToList();
        }

        public Vertex GetVertexById(long id)
        {
            return _dataContext.Vertices.Include(v => v.Edges).Include(v=>v.Floor)
                .Include(v => v.MainCharacterization).Include(v => v.SecondaryCharacterization).FirstOrDefault(v=>v.Id == id);
        }

        public Vertex AddVertex(Vertex vertex)
        {
            _dataContext.Vertices.Add(vertex);
            _dataContext.SaveChanges();
            return vertex;
        }

        public Vertex UpdateVertex(Vertex vertex)
        {
            Vertex vertexById = GetVertexById(vertex.Id);
            if (vertexById != null)
            {
                vertexById.Edges = vertex.Edges;
                vertexById.RoomNumber = vertex.RoomNumber;
                vertexById.Floor = vertex.Floor;
                vertexById.FloorId = vertex.FloorId;
                vertexById.MainCharacterization = vertex.MainCharacterization;
                vertexById.SecondaryCharacterization = vertex.SecondaryCharacterization;
                _dataContext.SaveChanges();
                return vertexById;
            }
            return null;
        }

        public void DeleteVertex(long id)
        {
            Vertex VertexById = GetVertexById(id);
            if (VertexById != null)
            {
                _dataContext.Remove(VertexById);
                _dataContext.SaveChanges();
            }
        }

        public void AddEdge(Edge edge, Vertex vertex)
        {
            vertex.Edges.Add(edge);
            _dataContext.Edeges.Add(edge);
            _dataContext.SaveChanges();
        }

    }
}
