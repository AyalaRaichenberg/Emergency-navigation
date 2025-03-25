using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;
using EmergencyNavigation.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyNavigation.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   [Authorize]
    public class VertexController :ControllerBase
    {
        private readonly IVertexServices _vertexService;

        public VertexController(IVertexServices vertexService)
        {
            _vertexService = vertexService;
        }

        // GET: api/<VertexController>
        [HttpGet]
        public IActionResult GetVertexList()
        {
            return Ok(_vertexService.GetVertexList());
        }

        // GET api/<VertexController>/5
        [HttpGet("{id}")]
        public IActionResult GetVertexById(long id)
        {
            Vertex vertex = _vertexService.GetVertexById(id);
            if (vertex == null)
            {
                return NotFound();
            }
            return Ok(vertex);
        }

        // POST api/<VertexController>
        [HttpPost]
        public IActionResult AddVertex([FromBody] Vertex vertex)
        {
            return StatusCode(201, _vertexService.AddVertex(vertex));
        }

        // PUT api/<VertexController>/5
        [HttpPut]
        public IActionResult UpdateVertex([FromBody] Vertex vertex)
        {
            Vertex u = _vertexService.UpdateVertex(vertex);
            if (u != null)
            {
                return NotFound();
            }
            return Ok(u);

        }

        // DELETE api/<VertexController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteVertex(long id)
        {
            _vertexService.DeleteVertex(id);
            return NoContent();
        }

        [HttpPost("{id}")]
        public IActionResult AddEdge(long id, [FromBody] Edge edge)
        {
            _vertexService.AddEdge(edge, id);
            return StatusCode(201);
        }
        [HttpPost("{buildingId}/{floorNumber}")]
        public IActionResult GetListByBuildingAndFloor(long buildingId, int floorNumber)
        {
            return Ok(_vertexService.GetListByBuildingAndFloor(buildingId, floorNumber));
        }
    }
}
