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
    public class FloorRepository:IFloorRepository
    {
        private readonly DataContext _dataContext;
        public FloorRepository(DataContext context)
        {
            _dataContext = context;
        }
        public List<Floor> GetFloors()
        {
            return _dataContext.Floor.Include(f => f.Vertices).ToList();
        }
        public Floor GetFloorById(long id)
        {
            return _dataContext.Floor
                .Include(f => f.Vertices)
                .FirstOrDefault(f => f.Id == id);
        }

        public Floor AddFloor(Floor floor)
        {
            _dataContext.Floor.Add(floor);
            _dataContext.SaveChanges();
            return floor;
        }

        public Floor UpdateFloor(Floor floor)
        {
            Floor floorById = GetFloorById(floor.Id);
            if (floorById != null)
            {
                floorById.FloorNumber = floor.FloorNumber;
                floorById.BuildingId = floor.BuildingId;
                _dataContext.SaveChanges();
                return floorById;
            }
            return null;
        }

        public void DeleteFloor(long id)
        {
            Floor floorById = GetFloorById(id);
            if (floorById != null)
            {
                _dataContext.Remove(floorById);
                _dataContext.SaveChanges();
            }
        }
        public List<Vertex> GetVerticesByFloor(long floorId)
        {
            Floor f = GetFloorById(floorId);
            if (f != null) {return f.Vertices; }
            return new List<Vertex>();
        }
    }
}
