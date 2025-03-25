using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.DTO
{
    public class NavigationWithLength
    {
        public double Length {get;set;}
        public List<Vertex> Navigation { get;set;}

        public NavigationWithLength(List<Vertex> navigation,double length)
        {
            Navigation = navigation;
            Length = length;
        }
    }
}
