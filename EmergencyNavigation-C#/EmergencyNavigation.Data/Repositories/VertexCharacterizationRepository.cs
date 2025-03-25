using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Repositories;
using EmergencyNavigation.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Data.Repositories
{
    public class VertexCharacterizationRepository : IVertexCharacterizationRepository
    {
        private readonly DataContext _dataContext;

        public VertexCharacterizationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<VertexCharacterization> GetVertexCharacterizationsList()
        {
            return _dataContext.VertexCharacterizations.ToList();
        }

        public VertexCharacterization GetVertexCharacterizationById(long id)
        {
            return _dataContext.VertexCharacterizations.Find(id);
        }

        public VertexCharacterization AddVertexCharacterization(VertexCharacterization vertexCharacterization)
        {
            _dataContext.VertexCharacterizations.Add(vertexCharacterization);
            _dataContext.SaveChanges();
            return vertexCharacterization;
        }

        public VertexCharacterization UpdateVertexCharacterization(VertexCharacterization vertexCharacterization)
        {
            VertexCharacterization vcById = GetVertexCharacterizationById(vertexCharacterization.Id);
            if (vcById != null)
            {
                vcById.Name = vertexCharacterization.Name;
                return vcById;
            }
            return null;
        }

        public void DeleteVertexCharacterization(long id)
        {
            VertexCharacterization vcById = GetVertexCharacterizationById(id);
            if (vcById != null)
            {
                _dataContext.Remove(vcById);
                _dataContext.SaveChanges();
            }
        }
    }
}