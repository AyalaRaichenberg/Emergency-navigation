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
    public class BuildingService : IBuildingService
    {
        public readonly IBuildingRepository _buildingRepository;
        public readonly IFloorRepository _floorRepository;

        public BuildingService(IBuildingRepository buildingRepository,IFloorRepository floorRepository)
        {
            _buildingRepository = buildingRepository;
            _floorRepository = floorRepository;
        }

        public List<Building> GetBuildings()
        {
            return _buildingRepository.GetBuildingList();
        }
        public Building GetBuildingById(long id)
        {
            return _buildingRepository.GetBuildingById(id);
        }
        public List<Floor> FloorsByBuildingId(long id)
        {
            return _buildingRepository.FloorsByBuildingId(id);
        }
        public List<Floor> FloorsByFoorId(long id)
        {
            long buildingId=_floorRepository.GetFloorById(id).BuildingId;
            return _buildingRepository.FloorsByBuildingIdWithOutCircles(buildingId);
        }
        public Building AddBuilding(Building building)
        {
            return _buildingRepository.AddBuilding(building);
        }
        public Building UpdateBuilding(Building building)
        {
            return _buildingRepository.UpdateBuilding(building);
        }
        public void DeleteBuilding(long id)
        {
            _buildingRepository.DeleteBuilding(id);
        }
    }

}