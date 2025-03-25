using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyNavigation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize]
    public class FloorController : ControllerBase
    {

        private readonly IFloorService _floorService;
        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public IActionResult GetFloors()
        {
           return Ok(_floorService.GetFloors());
        }

        [HttpGet("{id}")]
        public IActionResult GetFloorById(long id)
        {
            Floor floor= _floorService.GetFloorById(id);
            if (floor == null)
            {
                return NotFound();
            }
            return Ok(floor);
        }

        [HttpPost]
        public IActionResult AddFloor([FromBody] Floor floor)
        {
            return StatusCode(201,_floorService.AddFloor(floor));
        }

        [HttpPut]
        public IActionResult UpdateFloor([FromBody] Floor floor)
        {
            Floor f= _floorService.UpdateFloor(floor);
            if(f == null)
            {
                return NotFound();
            }
            return Ok(f);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFloor(long id)
        {
            _floorService.DeleteFloor(id);
            return NoContent();
        }
 

        [HttpGet("floors/{floorId}/vertices")]
        public IActionResult GetVerticesByFloor(long floorId)
        {
            return Ok(_floorService.GetVerticesByFloor(floorId));
        }

    }
}
