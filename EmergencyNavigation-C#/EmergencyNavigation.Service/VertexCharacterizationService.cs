using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Repositories;
using EmergencyNavigation.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Service
{
    public class VertexCharacterizationService : IVertexCharacterizationService
    {
        private readonly IVertexCharacterizationRepository _vertexCharacterizationRepository;

        public VertexCharacterizationService(IVertexCharacterizationRepository vertexCharacterizationRepository)
        {
            _vertexCharacterizationRepository = vertexCharacterizationRepository;
        }

        public List<VertexCharacterization> GetVertexCharacterizationsList()
        {
            return _vertexCharacterizationRepository.GetVertexCharacterizationsList();
        }

        public VertexCharacterization AddVertexCharacterization(VertexCharacterization vertexCharacterization)
        {
            return _vertexCharacterizationRepository.AddVertexCharacterization(vertexCharacterization);
        }

        public VertexCharacterization GetVertexCharacterizationById(long id)
        {
            return _vertexCharacterizationRepository.GetVertexCharacterizationById(id);
        }

        public VertexCharacterization UpdateVertexCharacterization(VertexCharacterization vertexCharacterization)
        {
            return _vertexCharacterizationRepository.UpdateVertexCharacterization(vertexCharacterization);
        }

        public void DeleteVertexCharacterization(long id)
        {
            _vertexCharacterizationRepository.DeleteVertexCharacterization(id);
        }
    }
}