using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Data.Repositories
{
    public class EdgeRepository : IEdgeRepository
    {
        private readonly DataContext _dataContext;

        public EdgeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Edge> GetEdgeList()
        {
            return _dataContext.Edeges.Include(e=>e.Vertex).ToList();
        }
        public Edge GetEdgeById(long id)
        {
            return _dataContext.Edeges.Find(id);
        }
        public Edge AddEdge(Edge edge)
        {
            _dataContext.Edeges.Add(edge);
            _dataContext.SaveChanges();
            return edge;
        }


        public Edge UpdateEdge(Edge edge)
        {
            Edge edgeById = GetEdgeById(edge.Id);
            if (edgeById != null)
            {
                edgeById.Vertex = edge.Vertex;
                edgeById.Meters = edge.Meters;

                _dataContext.SaveChanges();
                return edgeById;
            }
            return null;
        }

        public void DeleteEdge(long id)
        {
            Edge edgeById = GetEdgeById(id);
            if (edgeById != null)
            {
                _dataContext.Remove(edgeById);
                _dataContext.SaveChanges();
            }
        }


    }
}