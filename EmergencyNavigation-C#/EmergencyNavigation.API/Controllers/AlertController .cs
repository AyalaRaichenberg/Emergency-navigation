using EmergencyNavigation.Core.Hubs;
using EmergencyNavigation.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EmergencyNavigation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase

    {
        private readonly IHubContext<AlertHub> _hubContext;

        public AlertController(IHubContext<AlertHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendAlert([FromBody] Alert alert)
        {
            long managerId = GetManagerIdByBuilding(alert.BuildingId); 

            if (managerId <= 0) 
            {
                return BadRequest("Manager not found for this building.");
            }

            await _hubContext.Clients.User(managerId.ToString()).SendAsync("ReceiveAlert", alert);

            return Ok(new { message = "Alert sent successfully", alertId = Guid.NewGuid() });

        }

        private long GetManagerIdByBuilding(long buildingId)
        {
            return 1; 
        }

    }
}
