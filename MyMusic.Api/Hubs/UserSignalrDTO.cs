using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Api.Hubs
{
    public class UserSignalrDTO
    {
        public string UserId { get; set; }
        public List<string> SignalR_ConnectionIds { get; set; }
    }
}
