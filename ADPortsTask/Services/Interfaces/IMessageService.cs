using ADPortsTask.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADPortsTask.Services.Interfaces
{
    public interface IMessageService
    {
        Task SendAsync(Message message);
    }
}
