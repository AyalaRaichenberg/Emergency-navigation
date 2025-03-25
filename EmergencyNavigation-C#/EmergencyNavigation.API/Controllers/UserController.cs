using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyNavigation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetUsersList()
        {
            return Ok(_userService.GetUsersList());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(long id)
        {
            User user= _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            return StatusCode(201,_userService.AddUser(user));
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            User u= _userService.UpdateUser(user);
            if (u != null) {
                return NotFound();
            }
            return Ok(u);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
        [HttpGet("{email}/email")]
        public IActionResult CheckEmail(string email)
        {
            if (_userService.CheckEmail(email))
            {
                return Conflict();
            }
            else
            {
                return Ok();
            }
        }
    }
}
