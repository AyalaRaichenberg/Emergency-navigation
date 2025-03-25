using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;
using EmergencyNavigation.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyNavigation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BuildingController : ControllerBase
    {

        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        // GET: api/<BuildingController>
        [HttpGet]
        public IActionResult GetBuildingList()
        {

            return Ok(_buildingService.GetBuildings());
        }

        // GET api/<BuildingController>/5
        [HttpGet("{id}")]
        public IActionResult GetBuildingById(long id)
        {
            Building building = _buildingService.GetBuildingById(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }
        // POST api/<BuildingController>
        [HttpPost]
        public IActionResult AddBuilding([FromBody] Building building)
        {
            return StatusCode(201, _buildingService.AddBuilding(building));
        }

        // PUT api/<BuildingController>/5
        [HttpPut]
        public IActionResult UpdateBuilding([FromBody] Building building)
        {
            Building building1 = _buildingService.UpdateBuilding(building);
            if (building1 != null)
            {
                return NotFound();
            }
            return Ok(building);

        }

        // DELETE api/<BuildingController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBuilding(long id)
        {
            _buildingService.DeleteBuilding(id);
            return NoContent();
        }

        [HttpGet("floors/{floorId}")]
        public IActionResult GetFloorsByFloorId(long floorId)
        {
            return Ok(_buildingService.FloorsByFoorId(floorId));
        }
    }
}