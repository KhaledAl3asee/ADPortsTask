using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADPortsTask.Notification
{
    public class NotificationHub:Hub
    {
        
      
        public async Task<string> Test(string message)
        {
            return ("Message Sent");
        }
    }
}
