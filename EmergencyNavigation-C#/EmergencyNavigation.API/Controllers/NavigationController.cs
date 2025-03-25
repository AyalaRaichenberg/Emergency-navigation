using AutoMapper;
using EmergencyNavigation.Core.Model;
using EmergencyNavigation.API.Model;
using EmergencyNavigation.Core.Services;
using EmergencyNavigation.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyNavigation.API.Controllers
{

    [Route("api/controller")]
    [ApiController]
    public class NavigationController : ControllerBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMapper mapper;

        public NavigationController(INavigationService navigationService,IMapper _mapper)
        {
            _navigationService = navigationService;
            mapper=_mapper;
        }

        [HttpPost("defibrillator")]
        public IActionResult GetNavigationToDefribrelator([FromBody] long sourceId)
        {
           return Ok(mapper.Map<NavigationWithLengthModel>( _navigationService.NavigationToDefribrelator(sourceId)));
        }

        [HttpPost("protected-room")]
        public IActionResult GetNavigationToProtectedRoom([FromBody] long sourceId)
        {
            return Ok(mapper.Map < NavigationWithLengthModel > (_navigationService.NavigationToProtectedRoom(sourceId)));
        }

        [HttpPost("protected-room/no-stairs")]
        public IActionResult GetNavigationToProtectedRoomWithOutStaircase([FromBody] long sourceId)
        {
            return Ok(mapper.Map<NavigationWithLengthModel>(_navigationService.NavigationToProtectedRoomWithOutStaircase(sourceId)));
        }

        [HttpPost("top-floor")]
        public IActionResult GetNavigationToTopFloor([FromBody] long sourceId)
        {
            return Ok(mapper.Map<NavigationWithLengthModel>(_navigationService.NavigationToTopFloor(sourceId)));
        }

        [HttpPost("exit-building")]
        public IActionResult GetNavigationToExitingTheBuilding([FromBody] long sourceId)
        {
            return Ok(mapper.Map<NavigationWithLengthModel>( _navigationService.NavigationToExitingTheBuilding(sourceId)));
        }

        [HttpPost("exit-building/no-stairs")]
        public IActionResult GetNavigationToExitingTheBuildingOrToProtectedRoomWithOutStaircase([FromBody] long sourceId)
        {
            return Ok(mapper.Map < NavigationWithLengthModel > (_navigationService.NavigationToExitingTheBuildingOrToProtectedRoomWithOutStaircase(sourceId)));
        }



    }
}
