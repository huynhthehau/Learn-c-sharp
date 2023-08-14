using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebChatApp.Data.Entities;
using WebChatApp.Data;
using WebChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebChatApp.Controllers
{
    public class RoomsController : BaseController
    {
        private readonly ManageAppDbContext _context;
        private readonly IMapper _mapper;

        public RoomsController(ManageAppDbContext context,
          IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomViewModel>>> Get()
        {

            var rooms = await _context.Rooms.ToListAsync();

            var roomsViewModel = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(rooms);

            return Ok(roomsViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            var roomViewModel = _mapper.Map<Room, RoomViewModel>(room);
            return Ok(roomViewModel);
        }

    }
}
