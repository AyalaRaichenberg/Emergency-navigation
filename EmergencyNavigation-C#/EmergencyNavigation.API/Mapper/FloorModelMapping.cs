using EmergencyNavigation.Core.Model;
using AutoMapper;
using EmergencyNavigation.API.Model;
namespace EmergencyNavigation.API.Mapper
{
    public class FloorModelMapping : Profile
    {
        public FloorModelMapping()
        {
            CreateMap<Floor, FloorModel>().ReverseMap();
        }
    }
}