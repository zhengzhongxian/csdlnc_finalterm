using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.CoreHeplers
{
    public class ProgressHub : Hub
    {
        public async Task<string> GetConnectionId() { return await Task.FromResult(Context.ConnectionId); }
    }
}
