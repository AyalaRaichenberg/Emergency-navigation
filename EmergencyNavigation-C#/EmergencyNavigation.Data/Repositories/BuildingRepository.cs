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
    public class BuildingRepository : IBuildingRepository
    {
        private readonly DataContext _dataContext;
        public BuildingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Building> GetBuildingList()
        {
            return _dataContext.Buildings.Include(b => b.Floors).ToList();
        }
        public Building GetBuildingById(long id)
        {
            return _dataContext.Buildings.Find(id);
        }
        public Building AddBuilding(Building building)
        {
            _dataContext.Buildings.Add(building);
            _dataContext.SaveChanges();
            return building;
        }
        public Building UpdateBuilding(Building building)
        {
            Building buildingById = GetBuildingById(building.Id);
            if (buildingById != null)
            {
                buildingById.Address = building.Address;
                buildingById.NumberOfFloor = building.NumberOfFloor;
                buildingById.City = building.City;
                _dataContext.SaveChanges();
                return buildingById;
            }
            return null;
        }
        public void DeleteBuilding(long id)
        {
            Building buildingById = GetBuildingById(id);
            if (buildingById != null)
            {
                _dataContext.Remove(buildingById);
                _dataContext.SaveChanges();
            }
        }
        public List<Floor> FloorsByBuildingId(long id)
        {
            return _dataContext.Floor.Where(f => f.BuildingId == id)
                .Include(f => f.Vertices).ThenInclude(v => v.MainCharacterization).Include(f => f.Vertices)
            .ThenInclude(v => v.SecondaryCharacterization).Include(f => f.Vertices)
            .ThenInclude(v => v.Edges).ToList();
        }
        public List<Floor> FloorsByBuildingIdWithOutCircles(long id)
        {
            return _dataContext.Floor.Where(f => f.BuildingId == id)
                .Include(f => f.Vertices).ThenInclude(v => v.MainCharacterization).Include(f => f.Vertices)
            .ThenInclude(v => v.SecondaryCharacterization).ToList();
        }
    }
}