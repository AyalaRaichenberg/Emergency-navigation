using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Repositories
{
    public interface IBuildingRepository
    {
        public List<Building> GetBuildingList();
        public Building GetBuildingById(long id);
        public Building AddBuilding(Building building);
        public Building UpdateBuilding(Building building);
        public void DeleteBuilding(long id);
        public List<Floor> FloorsByBuildingId(long id);
        public List<Floor> FloorsByBuildingIdWithOutCircles(long id);

    }
}