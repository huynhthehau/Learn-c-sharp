using AutoMapper;
using DemoAuth.Data;
using DemoAuth.Entities;
using Microsoft.AspNetCore.SignalR;

namespace DemoAuth.Hubs
{
    public class ChatHub : Hub
    {
        public readonly static List<UserEntity> _connections = new List<UserEntity>();
        public readonly static Dictionary<string, string> _connectionsMap = new Dictionary<string, string>;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ChatHub(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
