using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Services
{
    public interface IFloorService
    {
        public List<Floor> GetFloors();
        public Floor AddFloor(Floor floor);
        public Floor GetFloorById(long id);
        public Floor UpdateFloor(Floor floor);
        public void DeleteFloor(long id);
        public List<Vertex> GetVerticesByFloor(long floorId);


    }
}
