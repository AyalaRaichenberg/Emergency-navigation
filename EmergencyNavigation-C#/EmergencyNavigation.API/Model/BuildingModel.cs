using EmergencyNavigation.Core.Model;

namespace EmergencyNavigation.API.Model
{
    public class BuildingModel
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public int NumberOfFloor { get; set; }
        public string City { get; set; }
    }
 
}
