using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Services
{
    public interface IVertexCharacterizationService
    {
        public List<VertexCharacterization> GetVertexCharacterizationsList();
        public VertexCharacterization AddVertexCharacterization(VertexCharacterization vertexCharacterization);
        public VertexCharacterization GetVertexCharacterizationById(long id);
        public VertexCharacterization UpdateVertexCharacterization(VertexCharacterization vertexCharacterization);
        public void DeleteVertexCharacterization(long id);
    }
}