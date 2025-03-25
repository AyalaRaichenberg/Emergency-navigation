using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyNavigation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EdgeController : ControllerBase
    {
        private readonly IEdgeService _edgeService;
        public EdgeController(IEdgeService edgeService)
        {
            this._edgeService = edgeService;
        }

        // GET: api/<EdgeController>
        [HttpGet]
        public IActionResult GetEdgeList()
        {
            return Ok(_edgeService.GetEdgeList());
        }

        // GET api/<EdgeController>/5
        [HttpGet("{id}")]
        public IActionResult GetEdgeById(long id)
        {
            Edge edge = _edgeService.GetEdgeById(id);
            if (edge == null)
            {
                return NotFound();
            }
            return Ok(edge);
        }

        //POST api/<EdgeController>
        [HttpPost]
        public IActionResult AddEdge([FromBody] Edge edge)
        {
            return StatusCode(201, _edgeService.AddEdge(edge));
        }

        // PUT api/<EdgeController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateEdge([FromBody] Edge edge)
        {
            Edge edge1 = _edgeService.UpdateEdge(edge);
            if (edge1 != null)
            {
                return NotFound();
            }
            return Ok(edge);

        }

        // DELETE api/<EdgeController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEdge(long id)
        {
            _edgeService.DeleteEdge(id);
            return NoContent();
        }
    }
}
