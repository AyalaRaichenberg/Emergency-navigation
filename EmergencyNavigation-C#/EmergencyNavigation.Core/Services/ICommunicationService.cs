using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Services
{
    public interface ICommunicationService
    {
        public void sendMassegesToParamedics(List<User> paramedics, Vertex location);
    }
}
