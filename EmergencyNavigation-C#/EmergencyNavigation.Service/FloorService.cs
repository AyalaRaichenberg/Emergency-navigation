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
    public class FloorService:IFloorService
    {
        private readonly IFloorRepository _floorRepository;
        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }
        public List<Floor> GetFloors()
        {
            return _floorRepository.GetFloors();
        }
        public Floor AddFloor(Floor floor)
        {
            return _floorRepository.AddFloor(floor);
        }
        public Floor GetFloorById(long id)
        {
            return _floorRepository.GetFloorById(id);
        }
        public Floor UpdateFloor(Floor floor)
        {
           return  _floorRepository.UpdateFloor(floor);
        }
        public void DeleteFloor(long id)
        {
            _floorRepository.DeleteFloor(id);
        }

        public List<Vertex> GetVerticesByFloor(long floorId)
        {
            return _floorRepository.GetVerticesByFloor(floorId);
        }
    }
}
