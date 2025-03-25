using AutoMapper;
using EmergencyNavigation.Core.DTO;
using EmergencyNavigation.API.Model;

namespace EmergencyNavigation.API.Mapper
{
    public class NavigationWithLengthMapper:Profile
    {
        public NavigationWithLengthMapper() {
        CreateMap<NavigationWithLength,NavigationWithLengthModel>().ReverseMap();
        }
    }
}
