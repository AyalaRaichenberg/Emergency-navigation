using EmergencyNavigation.Core.Model;

namespace EmergencyNavigation.API.Model
{
    public class NavigationWithLengthModel
    {
        public double Length { get; set; }
        public List<VertexModel> Navigation { get; set; }
    }
}
