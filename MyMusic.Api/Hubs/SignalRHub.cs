//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.SignalR;
//using MyMusic.Data.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Threading.Tasks;

//namespace MyMusic.Api.Hubs
//{
//    [Authorize]
//    public class SignalRHub : Hub
//    {
//        private readonly MyMusicDbContext _dbContext;
//        private readonly UserManager<ApplicationUser> _userManger;

//        public SignalRHub(MyMusicDbContext dbContext,
//                            UserManager<ApplicationUser> userManager)
//        {
//            _dbContext = dbContext;
//        }

//        public override Task OnConnectedAsync()
//        {
//            var user = await _userManger.FindByNameAsync(Context.User.Identity.Name);

//            //every time a user connects to the application, a signalr connection is created
//            //When refresh the browser or exit from the browser, then the OnDisconnected is fired and
//            //deletes the previous signalr connectionId from the database and creates, a new one from this user.
//            //If user logs with another device(or another browser), then a new signalr connection is created and
//            //the previous one is not deleted.

//            //get the user connectionId to the Hub
//            var connectionId = Context.ConnectionId;

//            UserSignalR newUserSignalrConnection = new UserSignalR
//            {
//                UserId = user.Id,
//                UserName = user.FirstName + user.LastName,
//                SignalrConnId = connectionId,
//                DateTime = DateTime.Now
//            };
//            await _dbContext.UserSignalR.AddAsync(newUserSignalrConnection);
//            await _dbContext.SaveChangesAsync();

//            //get all records with SignalRConnectionsId for currentUser
//            List<UserSignalrDTO> onlineFriends = await GetConnectionUsersByUserId(user.Id);

//            //send the list with online friends to caller in front-end
//            //await Clients.Caller.SendAsync("sendOnlineUsers", onlineFriends);
//            //send newUserSignalrConnection (the caller) to all his friends in front-end
//            if (onlineFriends.Count > 0)
//            {
//                await Clients.Clients(onlineFriends.SelectMany(x => x.SignalR_ConnectionIds).ToArray()).SendAsync("sendCallerInfo", newUserSignalrConnection);
//            }
//            return base.OnConnectedAsync();
//        }

//        public async Task<List<UserSignalrDTO>> GetConnectionUsersByUserId(string currentUserId)
//        {
//            //get the list of connection users
//            List<string> listOfConnectionUsers = await _userConnectionContext.GetListOfConnectionUsers(currentUserId, null);

//            var myFriendConnections = await _dbContext.UserSignalR.AsNoTracking().Where(x => x.UserId != currentUserId &&
//                                                                                        listOfConnectionUsers.Any(y => x.UserId == y)).toListAsync();

//            var result = myFriendConnections.GroupBy(x => x.UserId).Select(g => new UserSignalrDTO { UserId = g.Key,
//                                                                                                      SignalR_ConnectionIds = g.Select(d => d.SignalrConnId).ToList()}).ToList();

//            return result;
//        }

//        //connection heartbeat sent by front-end
//        public void UpdateConnection()
//        {
//            string connectionId = Context.ConnectionId;
//            _dbContext.UserSignalR.Where(x => x.SignalrConnId == connectionId).FirstOrDefault().DateTime = DateTime.UtcNow;
//            _dbContext.SaveChanges();
//        }
//    }

//    //to inject hub to services:
//    //private read only IHubContext<SignalRHub> _hubContext;
//    //await _hubContext.Clients.Client(listOfSignalRConnections.ToArray()).SendAsync("acceptValidationRequest", new {res = response, role = roleName});
//}
