using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Api.Hubs
{
    public class UserSignalR
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string SignalrConnId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
