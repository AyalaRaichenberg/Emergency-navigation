using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;

namespace EmergencyNavigation.Service
{
    public class CommunicationService : ICommunicationService
    {
        public void sendMassegesToParamedics(List<User> paramedics,Vertex location)
        {
            foreach (User paramedic in paramedics)
            {
                Console.WriteLine("come fast!!"+location); 
            }
        }
    }
}
