using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Model
{
    public class Building
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public int NumberOfFloor { get; set; }
        public string City { get; set; }
        public List<Floor> Floors { get; set; } = new List<Floor>();
    }
}