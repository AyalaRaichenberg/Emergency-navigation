using EmergencyNavigation.Core.Model;

namespace EmergencyNavigation.API.Model
{
    public class FloorModel
    {
        public long Id { get; set; }
        public int FloorNumber { get; set; }
        public long BuildingId { get; set; }
    }
}
