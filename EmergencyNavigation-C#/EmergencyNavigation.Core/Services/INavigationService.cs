using EmergencyNavigation.Core.DTO;
using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Services
{
    public interface INavigationService
    {
        public NavigationWithLength NavigationToDefribrelator(long sourceId);
        public NavigationWithLength NavigationToProtectedRoom(long sourceId);
        public NavigationWithLength NavigationToProtectedRoomWithOutStaircase(long sourceId);
        public NavigationWithLength NavigationToTopFloor(long sourceId);
        public NavigationWithLength NavigationToExitingTheBuilding(long sourceId);
        public NavigationWithLength NavigationToExitingTheBuildingOrToProtectedRoomWithOutStaircase(long sourceId);        
    }
}
