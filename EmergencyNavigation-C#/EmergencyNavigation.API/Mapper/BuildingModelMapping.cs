using EmergencyNavigation.API.Model;
using AutoMapper;
using EmergencyNavigation.Core.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmergencyNavigation.API.Mapper
{
    public class BuildingModelMapping : Profile
    {
        public BuildingModelMapping()
        {
            CreateMap<Building, BuildingModel>().ReverseMap();
        }
    }
}
