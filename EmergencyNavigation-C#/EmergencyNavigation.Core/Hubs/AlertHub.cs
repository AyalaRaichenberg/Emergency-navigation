using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using EmergencyNavigation.Core.Model;
using Microsoft.AspNetCore.SignalR;

namespace EmergencyNavigation.Core.Hubs
{
    public class AlertHub : Hub
    {
        public async Task SendAlertToManager(long managerId, long buildingId, string alertType, Vertex dangerLocation)
        {
            var alertData = new
            {
                BuildingId = buildingId,
                AlertType = alertType,
                DangerLocation = dangerLocation
            };
            Console.WriteLine($"Sending alert to manager {managerId} for building {buildingId}: {alertType}");

            await Clients.User(managerId.ToString()).SendAsync("ReceiveAlert", alertData);
        }


    }
}
