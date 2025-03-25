using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;
using EmergencyNavigation.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyNavigation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize]

    public class VertexCharacterizationController : ControllerBase
    {
        private readonly IVertexCharacterizationService _vertexCharacterizationService;

        public VertexCharacterizationController(IVertexCharacterizationService vertexCharacterizationService)
        {
            _vertexCharacterizationService = vertexCharacterizationService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetVertexCharacterizationsList()
        {
            return Ok(_vertexCharacterizationService.GetVertexCharacterizationsList());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetVertexCharacterizationById(long id)
        {
            VertexCharacterization vertexCharacterization = _vertexCharacterizationService.GetVertexCharacterizationById(id);
            if (vertexCharacterization == null)
            {
                return NotFound();
            }
            return Ok(vertexCharacterization);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult AddVertexCharacterization([FromBody] VertexCharacterization vertexCharacterization)
        {
            return StatusCode(201, _vertexCharacterizationService.AddVertexCharacterization(vertexCharacterization));
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public IActionResult UpdateVertexCharacterization([FromBody] VertexCharacterization vertexCharacterization)
        {
            VertexCharacterization vc = _vertexCharacterizationService.UpdateVertexCharacterization(vertexCharacterization);
            if (vc != null)
            {
                return NotFound();
            }
            return Ok(vc);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteVertexCharacterization(long id)
        {
            _vertexCharacterizationService.DeleteVertexCharacterization(id);
            return NoContent();
        }
    }
}