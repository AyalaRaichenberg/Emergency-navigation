using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Services
{
    public interface IBuildingService
    {
        public List<Building> GetBuildings();
        public Building GetBuildingById(long id);
        public Building AddBuilding(Building building);
        public Building UpdateBuilding(Building building);
        public void DeleteBuilding(long id);
        public List<Floor> FloorsByBuildingId(long id);
        public List<Floor> FloorsByFoorId(long id);

    }

}