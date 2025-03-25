using EmergencyNavigation.Core.Model;

namespace EmergencyNavigation.API.Model
{
    public class VertexModel
    {
        public long Id { get; set; }
        public int RoomNumber { get; set; }
        public long FloorId { get; set; }
        public VertexCharacterization? MainCharacterization { get; set; }
        public VertexCharacterization? SecondaryCharacterization { get; set; }
    }
}
