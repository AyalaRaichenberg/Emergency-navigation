using AutoMapper;
using EmergencyNavigation.API.Model;
using EmergencyNavigation.Core.Model;

namespace EmergencyNavigation.API.Mapper
{
    public class VertexModelMapping : Profile
    {
        public VertexModelMapping()
        {
            CreateMap<Vertex, VertexModel>();
        }
    }
}