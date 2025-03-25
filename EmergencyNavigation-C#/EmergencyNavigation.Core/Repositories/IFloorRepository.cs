using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Repositories
{
    public interface IFloorRepository
    {
        public List<Floor> GetFloors();
        public Floor AddFloor(Floor floor);
        public Floor GetFloorById(long id);
        public Floor UpdateFloor(Floor flor);
        public void DeleteFloor(long id);

        public List<Vertex> GetVerticesByFloor(long floorId);


    }
}
