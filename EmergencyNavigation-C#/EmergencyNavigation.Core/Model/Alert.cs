using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Model
{
    public class Alert
    {
        public String AlertType { get; set; }
        public Vertex DangerLocation { get; set; }
        public long BuildingId { get; set; }
    }
}
